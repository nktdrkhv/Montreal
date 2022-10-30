using Microsoft.Extensions.Logging;
using Stateless;
using Geolocation;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure.Behaviours;

public class PersonBehaviour : IChatBehaviour
{

    #region Infrastructure variables

    public ITelegramChat Chat { get; set; }
    BotDbContext _context = new();
    private ILogger<PersonBehaviour> _logger;

    #endregion Infrastructure variables

    // -------------------------------------------------------------------//

    #region Ctor with FSM

    public PersonBehaviour(Person person, ITelegramChat chat, ILogger<PersonBehaviour> logger)
    {
        Chat = chat;
        _person = person;
        _logger = logger;

        _machine = new StateMachine<PersonState, Trigger>(() => _state, s => _state = s);
        _textTrigger = _machine.SetTriggerParameters<string>(Trigger.Text);
        _pollAnswerTrigger = _machine.SetTriggerParameters<string>(Trigger.PollAnswer);
        _commandTrigger = _machine.SetTriggerParameters<Command>(Trigger.Command);
        _contentTrigger = _machine.SetTriggerParameters<ContentPointer>(Trigger.Pointer);
        _mediaTrigger = _machine.SetTriggerParameters<Media>(Trigger.Media);

        Configure();
        _machine.Activate();
    }

    private PersonState _state = PersonState.Initializing;
    private StateMachine<PersonState, Trigger> _machine;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<string> _textTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<string> _pollAnswerTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<ContentPointer> _contentTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<Command> _commandTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<Media> _mediaTrigger;

    #endregion Ctor with FSM

    // -------------------------------------------------------------------//

    #region Configuration

    private void Configure()
    {
        _context.Attach(_person);

        _machine.Configure(PersonState.Initializing)
            .PermitDynamic<Command>(_commandTrigger, InitialDestinationStateSelector)
            .Permit(Trigger.Text, PersonState.Starting)
            .Permit(Trigger.Media, PersonState.Starting)
            .Permit(Trigger.Pointer, PersonState.Viewing)
            .OnActivate(() =>
            {
                // todo: может произойти ошибка
                _currentContent = _context.Activities.Where(a => a.Performer.Id == _person.Id).OrderByDescending(a => a.CurrentTime).Select(a => a.Pointer).FirstOrDefault();
                if (_currentContent is not null)
                    HandleCurrent(_currentContent);
            });

        _machine.Configure(PersonState.Starting)
            .Ignore(Trigger.Text)
            .Ignore(Trigger.Media)
            .Permit(Trigger.Pointer, PersonState.Viewing)
            .OnEntryAsync(async () =>
            {
                var startStage = _context.Stages.Where(s => s.Type == StageType.Welcome).SingleOrDefault();
                if (startStage is not null)
                    await _machine.FireAsync<ContentPointer>(_contentTrigger, new() { Type = ContentType.Stage, Stage = startStage });
            });

        _machine.Configure(PersonState.Viewing)
            .Ignore(Trigger.Text)
            .Ignore(Trigger.Media)
            .PermitReentry(Trigger.Command)
            .PermitReentry(Trigger.Pointer)
            .OnEntryFromAsync<Command>(_commandTrigger, async (cmd) =>
            {
                switch (cmd.Name)
                {
                    case "start":
                        if (cmd.Arguments is string startArgs && MatchStringData(startArgs) is ContentPointer pointer)
                            await _machine.FireAsync(_contentTrigger, pointer);
                        else
                        {
                            var startStage = _context.Stages.Where(s => s.Type == StageType.Welcome).Single();
                            await _machine.FireAsync<ContentPointer>(_contentTrigger, new() { Type = ContentType.Stage, Stage = startStage });
                        }
                        break;
                    case "back":
                        if (FindPreviousContent(_currentContent) is ContentPointer prevoiousContent && _currentContent is ContentPointer presentContent)
                        {
                            //todo: вынести вовне
                            _allowedLinks.Clear();
                            _allowedPlaces.Clear();
                            _preparedFragments.Clear();
                            _replacementSteps.Clear();
                            _keyboardButtons.Clear();

                            await Chat.SendStatusAsync();
                            _currentContent = prevoiousContent;
                            HandleCurrent(presentContent);
                            await DemonstrateFragments(_preparedFragments!);
                        }
                        break;
                    case "replace":
                        if (cmd.Arguments is string uniqueId && _replacementSteps.Find(rs => rs.uniqueId == uniqueId).replacement is Step replacementStep)
                        {
                            _currentContent = new() { Step = replacementStep, Type = ContentType.Step };
                            HandleCurrent(_currentContent, true);

                            if (_preparedFragments.First().payload is Fragment determinedFragment)
                                await Chat.EditAsync(determinedFragment, uniqueId);
                        }
                        break;
                    case "choose":
                        await Chat.SendStatusAsync();
                        var chooseStage = _context.Stages.Where(s => s.Type == StageType.RouteList).SingleOrDefault();
                        if (chooseStage is not null)
                            await _machine.FireAsync<ContentPointer>(_contentTrigger, new() { Type = ContentType.Stage, Stage = chooseStage });
                        break;
                    case "spot":
                        if (_allowedPlaces.Count == 0)
                            await Chat.SendAsync("Конкретное место не указано 😅");
                        else
                            foreach (var place in _allowedPlaces)
                                await Chat.SendAsync(place.coordinate);
                        break;
                    default:
                        break;
                }
            })
            .OnEntryFromAsync<ContentPointer>(_contentTrigger, async pointer =>
            {
                //todo: Chat.RemoveInlineButtons (у тех, что именованы)
                await Chat.SendStatusAsync();
                NewCurrentDefine(pointer);
                HandleCurrent(_currentContent!);
                await DemonstrateFragments(_preparedFragments!);

                if (_currentContent is not null)
                {
                    //todo: поиск существующего поинтера, чтобы не плодить... и исключить из каскадого удаления
                    var activity = new Activity() { Performer = _person, Pointer = _currentContent! };
                    _context.Activities.Add(activity);
                    _previousTime = activity.CurrentTime;
                    await _context.SaveChangesAsync();
                }
            });



        _machine.OnUnhandledTriggerAsync(async (_, _) =>
        {
            // todo, показать существующие кнопки?
            var now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (_unhandledNotificationHold < now)
            {
                await Chat.SendAndDeleteAsync($"Что-то не то 😕\nПопробуйте воспользоваться командами из меню", 5);
                _unhandledNotificationHold = now + 5000;
            }
            await Chat.DeleteRecievedMessageAsync();
        });
    }

    #endregion Configuration

    // -------------------------------------------------------------------//

    #region Business logic variables

    private Person _person;
    private ContentPointer? _currentContent;
    //private Condition? _cuurrentConditions;
    private long _unhandledNotificationHold = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    private long _previousTime = long.MaxValue;

    private List<(Spot coordinate, Stage stage)> _allowedPlaces = new();
    private List<(string label, ContentPointer pointer)> _allowedLinks = new();
    private Queue<List<string>> _keyboardButtons = new();
    private List<(Fragment payload, int delay, bool hasInlineButton)> _preparedFragments = new();
    private List<(string uniqueId, Step replacement)> _replacementSteps = new();

    #endregion Business logic variables

    // -------------------------------------------------------------------//

    #region Business logic

    private ContentPointer? MatchStringData(string stringPointer)
    {
        string[] pointerParts = stringPointer.Trim().Split(':');
        if (pointerParts.Length == 0)
            return null;

        ContentPointer pointer = new();
        foreach (var part in pointerParts ?? Array.Empty<string>())
        {
            var splittedPart = part?.Trim().Split('=');
            if (splittedPart is null)
                return null;
            switch (splittedPart[0])
            {
                case "r":
                case "route":
                    pointer.Route = _context.Routes.Where(r => r.Name == splittedPart[1]).SingleOrDefault();
                    if (pointer.Route is null)
                        return null;
                    pointer.Type = pointer.Type | ContentType.Route;
                    break;
                case "sg":
                case "stage":
                    pointer.Stage = _context.Stages.Where(s => s.Name == splittedPart[1]).SingleOrDefault();
                    if (pointer.Stage is null)
                        return null;
                    pointer.Type = pointer.Type | ContentType.Stage;
                    break;
                case "sp":
                case "step":
                    pointer.Step = _context.Steps.Where(s => s.Name == splittedPart[1]).SingleOrDefault();
                    if (pointer.Step is null)
                        return null;
                    pointer.Type = pointer.Type | ContentType.Step;
                    break;
                default:
                    return null;
            }
        }
        return pointer;
    }

    private ContentPointer? FindPreviousContent(ContentPointer? pointer)
    {
        var previous = (from a in _context.Activities
                        where a.Performer.Id == _person.Id && a.CurrentTime < _previousTime
                        orderby a.CurrentTime descending
                        select a).FirstOrDefault();
        if (previous is not null)
            _previousTime = previous.CurrentTime;
        return previous?.Pointer;
    }

    private PersonState InitialDestinationStateSelector(Command cmd)
    {
        return cmd.Name switch
        {
            "start" when !string.IsNullOrWhiteSpace(cmd.Arguments) => PersonState.Viewing,
            "choose" => PersonState.Viewing,
            _ => PersonState.Starting,
        };
    }

    private void NewCurrentDefine(ContentPointer pointer)
    {
        //todo: возможны утечки памяти, проверить
        switch (pointer.Type)
        {
            case ContentType.Route:
                _currentContent = new() { Route = pointer!.Route, Stage = pointer!.Route!.InitialStage, Type = ContentType.Route | ContentType.Stage };
                break;
            case ContentType.Route | ContentType.Stage:
            case ContentType.Stage:
                //todo: при открытии паршрута по ссылке проблемы, если не было обработки ранее
                if (_currentContent?.Route is not null && _currentContent?.Stage is not null)
                {
                    var sequence = (from s in _context.Sequences
                                    where s.AttachedRoute.Id == _currentContent!.Route.Id &&
                                        s.From.Id == _currentContent!.Stage.Id &&
                                        s.To.Id == pointer!.Stage!.Id
                                    select s).SingleOrDefault();
                    if (sequence is not null)
                        _currentContent = new() { Route = sequence.AttachedRoute, Stage = pointer!.Stage, Type = ContentType.Route | ContentType.Stage };
                    else
                        _currentContent = new() { Stage = pointer!.Stage, Type = ContentType.Stage };
                }
                else if (pointer?.Route is not null)
                    _currentContent = new() { Route = pointer!.Route, Stage = pointer!.Stage, Type = ContentType.Stage | ContentType.Route };
                else
                    _currentContent = new() { Stage = pointer!.Stage, Type = ContentType.Stage };
                break;
            case ContentType.Step:
                if (_currentContent?.Route is not null && _currentContent?.Stage is not null)
                {
                    var pointers = from sequence in _context.Sequences
                                   join step in _context.StepsInStage on sequence.To.Id equals step.AttachedStage.Id
                                   where sequence.AttachedRoute.Id == _currentContent!.Route.Id && step.Payload.Id == pointer!.Step!.Id
                                   select new ContentPointer()
                                   {
                                       Route = sequence.AttachedRoute,
                                       Stage = step.AttachedStage,
                                       Step = step.Payload,
                                       Type = ContentType.All
                                   };
                    //todo:два запроса получается
                    if (pointers.Count() == 1)
                        _currentContent = pointers.Single();
                    else
                        _currentContent = new() { Step = pointer!.Step, Type = ContentType.Step };
                }
                else if (_currentContent?.Route is not null)
                {

                }
                else
                    _currentContent = new() { Step = pointer!.Step, Type = ContentType.Step };
                break;
            case ContentType.Stage | ContentType.Step:
                if (_currentContent?.Route is not null && _currentContent?.Stage is not null)
                {
                    var pointers = from sequence in _context.Sequences
                                   join step in _context.StepsInStage on sequence.To equals step.AttachedStage
                                   where sequence.AttachedRoute.Id == _currentContent!.Route.Id &&
                                        step.AttachedStage.Id == pointer!.Stage!.Id &&
                                        step.Payload.Id == pointer!.Step!.Id
                                   select new ContentPointer()
                                   {
                                       Route = sequence.AttachedRoute,
                                       Stage = step.AttachedStage,
                                       Step = step.Payload,
                                       Type = ContentType.All
                                   };
                    if (pointers.Count() == 1)
                        _currentContent = pointers.Single();
                    else
                        _currentContent = new() { Stage = pointer!.Stage, Step = pointer!.Step, Type = ContentType.Stage | ContentType.Step };
                }
                else
                    _currentContent = new() { Stage = pointer!.Stage, Step = pointer!.Step, Type = ContentType.Stage | ContentType.Step };
                break;
            // case ContentType.Route | ContentType.Stage:
            //     throw new NotImplementedException();
            case ContentType.Route | ContentType.Step:
                throw new NotImplementedException();
            case ContentType.All:
                _currentContent = pointer;
                break;
            default:
                _currentContent = null;
                return;
        }
    }

    private void HandleCurrent(ContentPointer pointer, bool isReplacementProcess = false)
    {
        //Chat.ClearMessageButtons();
        if (isReplacementProcess)
        {
            _preparedFragments.Clear();
            _replacementSteps.Clear();
            _keyboardButtons.Clear();
            //_currentConditions = null;
        }
        else
        {
            _allowedLinks.Clear();
            _allowedPlaces.Clear();
            _preparedFragments.Clear();
            _replacementSteps.Clear();
            _keyboardButtons.Clear();
            //_currentConditions = null;
        }

        if (pointer.Type.HasFlag(ContentType.Stage) && !isReplacementProcess && _currentContent?.Stage is Stage stage)
        {
            HandleStage(stage, _currentContent?.Step);
            if (pointer.Type.HasFlag(ContentType.Route) && _currentContent?.Route is Route route)
            {
                var availableStages = (from s in _context.Sequences
                                       where s.AttachedRoute.Id == route.Id && s.From.Id == stage.Id
                                       select s.To).ToList();

                var notPresent = new List<Stage>();
                foreach (var available in availableStages)
                    if (_allowedLinks.Find(l => l.pointer?.Stage?.Id == available!.Id).pointer is null) //todo:check
                        notPresent.Add(available);

                bool isLabelessSpot = false;
                bool isLabelessStage = false;
                foreach (var indirect in notPresent) //todo: внешний источник текста для 📍 Я на месте
                {
                    if (indirect.Location is Spot spot)
                    {
                        _allowedPlaces.Add((spot, stage));
                        string label;

                        if ((spot.Address ?? spot.Label) is string place)
                            label = $"📍 Я на {place}";
                        else if (spot.Number is int number)
                            label = $"📍 Я на месте №{number}";
                        else if (isLabelessSpot is false)
                        {
                            label = $"📍 Я на месте";
                            isLabelessSpot = true;
                        }
                        else
                            continue;

                        _allowedLinks.Add((label, new() { Stage = indirect, Type = ContentType.Stage }));
                        _keyboardButtons.Enqueue(new() { label });
                    }
                    else
                    {
                        string label;

                        if (indirect.Label is string stageLabel)
                            label = $"🔎 Что дальше? {stageLabel}";
                        else if (isLabelessStage is false)
                        {
                            label = $"💡 Что дальше?";
                            isLabelessStage = true;
                        }
                        else
                            continue;

                        _allowedLinks.Add((label, new() { Stage = indirect, Type = ContentType.Stage }));
                        _keyboardButtons.Enqueue(new() { label });
                    }
                }
            }
        }
        else if (pointer.Type.HasFlag(ContentType.Step) && _currentContent?.Step is Step onlyStep)
            HandleStep(onlyStep, 0);
    }

    private void HandleStage(Stage stage, Step? step = null)
    {
        var orderedSteps = stage.Steps.OrderBy(s => s.Order).AsEnumerable();
        bool isStepReached = step is null;

        foreach (var s in orderedSteps ?? Enumerable.Empty<StepInStage>())
            if (isStepReached)
                HandleStep(s.Payload, s.Delay);
            else if (s.Payload.Id == step?.Id)
            {
                isStepReached = true;
                HandleStep(s.Payload, s.Delay);
            }
    }

    private void HandleStep(Step step, int delay)
    {
        //todo: желательно подгружать не всю коллекцию, а только подходящий фрагмент
        _context.Entry(step).Collection(s => s.Fragments).Load();
        if (FragmentDetermine(step) is Fragment fragment)
        {
            var keyboardLine = new List<string>();
            var isLinked = fragment.Buttons is null ? false :
                    fragment.Buttons.Count() == 0 || fragment.Buttons.First().Type == ButtonType.KeyboardTransition ? false : true;
            //var isLinked = fragment.Buttons?.Count() == 0; //todo: некорректное срабатывание
            _preparedFragments.Add((fragment, delay, isLinked));
            foreach (var button in fragment?.Buttons ?? Enumerable.Empty<Button>())
            {
                //todo : проверка на наличие лейбла 
                if (button.Type is ButtonType.InlineReplace
                    && button?.Target?.Pointer?.Step is Step replacement)
                {
                    button.UniqueId = Guid.NewGuid().ToString()[..7];
                    _replacementSteps.Add((button.UniqueId, replacement));
                }

                if (button?.Label is string label && button?.Target?.Pointer is ContentPointer pointer)
                    if (button?.Type is ButtonType.KeyboardTransition)
                    {
                        keyboardLine.Add(label);
                        _allowedLinks.Add((label, pointer));
                    }
                    else if (button?.Type is ButtonType.InlineTransition)
                    {
                        button.UniqueId = Guid.NewGuid().ToString()[..7];
                        _allowedLinks.Add((button.UniqueId, pointer));
                    }
            }
            if (keyboardLine.Count > 0)
                _keyboardButtons.Enqueue(keyboardLine);
        }
    }

    private Fragment? FragmentDetermine(Step step) => step.Fragments.Where(f => f.Conditions == null).First(); //todo: compare with current conditions

    private async Task DemonstrateFragments(List<(Fragment payload, int delay, bool isLinked)> fragments)
    {
        bool keyboardIsSent = _keyboardButtons.Count() > 0 ? false : true;

        Fragment? firstUnlinked = null;
        Fragment? lastUnLinked = null;
        foreach (var frmt in fragments)
            if (!frmt.isLinked)
            {
                if (firstUnlinked is null)
                    firstUnlinked = frmt.payload;
                lastUnLinked = frmt.payload;
            }
        if (firstUnlinked?.Id == lastUnLinked?.Id)
            firstUnlinked = null;

        foreach (var fragment in fragments)
        {
            //await Chat.SendStatusAsync();
            switch (fragment.payload.Type)
            {
                case FragmentType.Location:
                case FragmentType.Text:
                case FragmentType.Media:
                    await Task.Delay(TimeSpan.FromSeconds(fragment.delay));
                    if (fragment.payload.Id == firstUnlinked?.Id)
                        await Chat.SendAsync(fragment.payload, clearReplyMarkup: true);
                    else if (fragment.payload.Id == lastUnLinked?.Id)
                        await Chat.SendAsync(fragment.payload, _keyboardButtons);
                    else
                        await Chat.SendAsync(fragment.payload);
                    break;
                case FragmentType.Timer:
                    if (fragment.payload.Timer?.Target is Target target && target.IsBinded)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(fragment.payload.Timer!.Delay));
                        await _machine.FireAsync<ContentPointer>(_contentTrigger, fragment.payload.Timer.Target.Pointer!);
                        return;
                    }
                    else if (fragment.payload.Timer?.Delay is int delay)
                        await Task.Delay(TimeSpan.FromSeconds(delay));
                    break;
                default:
                    break;
            }
        }
    }

    #endregion Business Logic

    // -------------------------------------------------------------------//

    #region IChatBehaviour

    public async Task SubmitAsync(string text)
    {
        var pointer = _allowedLinks.Find(button => button.label == text).pointer;
        if (pointer is not null)
            await _machine.FireAsync<ContentPointer>(_contentTrigger, pointer);
        else
            await _machine.FireAsync<string>(_textTrigger, text);
    }
    public async Task SubmitAsync(Command command) => await _machine.FireAsync<Command>(_commandTrigger, command);
    public async Task SubmitAsync(Media media) => await _machine.FireAsync<Media>(_mediaTrigger, media);
    public async Task SubmitAsync(Spot submitted)
    {
        var results = from loc in _allowedPlaces
                      let distanse = GeoCalculator.GetDistance(submitted.Latitude, submitted.Longitude, loc.coordinate.Latitude, loc.coordinate.Longitude, distanceUnit: DistanceUnit.Meters)
                      where distanse <= 25 //todo: учесть погрешность 
                      orderby distanse
                      select loc.stage;
        if (results.Count() > 0)
            await _machine.FireAsync<ContentPointer>(_contentTrigger, new() { Stage = results.First(), Type = ContentType.Stage });
    }

    public void Dispose() { _context.Dispose(); }

    #endregion IChatBehaviour
}