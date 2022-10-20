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
    private IAppRepository _repo;
    private ILogger<PersonBehaviour> _logger;

    #endregion Infrastructure variables

    // -------------------------------------------------------------------//

    #region Ctor with FSM

    public PersonBehaviour(Person person, ITelegramChat chat, IAppRepository repo, ILogger<PersonBehaviour> logger)
    {
        Chat = chat;
        _person = person;
        _repo = repo;
        _logger = logger;

        _machine = new StateMachine<PersonState, Trigger>(() => _state, s => _state = s);
        _textTrigger = _machine.SetTriggerParameters<string>(Trigger.Text);
        _pollAnswerTrigger = _machine.SetTriggerParameters<string>(Trigger.PollAnswer);
        _commandTrigger = _machine.SetTriggerParameters<Command>(Trigger.Command);
        _contentTrigger = _machine.SetTriggerParameters<ContentPointer>(Trigger.Pointer);
        _mediaTrigger = _machine.SetTriggerParameters<Media>(Trigger.Media);

        Configure();
    }

    private PersonState _state = PersonState.Initial;
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
        _machine.Configure(PersonState.Initial)
            .PermitDynamic<Command>(_commandTrigger, InitialDestinationStateSelector);

        _machine.Configure(PersonState.Start)
            .OnEntry(() =>
            {
                var startStage = _repo.Stages.Where(s => s.Type == StageType.Start).FirstOrDefault();
                if (startStage is not null)
                    _machine.FireAsync<ContentPointer>(_contentTrigger, new() { Stage = startStage });
            });


        // посмотреть что просят
        // посмотреть что есть и можно ли связать по схеме
        // подготовить кнопки, геопозиции и т.д (загрузить)
        // передать в демонстрацию? или отправляет подготовка, а демонстрация ждет?

        // ждем ответы, перенаправляя на подготовку в случае этапов
        //      либо в опросы в случае ответа 
        //      либо в получение данных, если ожидаем их, причем заранее перевод

        _machine.Configure(PersonState.Viewing)
            .PermitReentry(Trigger.Pointer)
            .OnEntryFrom<ContentPointer>(_contentTrigger, async pointer =>
            {
                NewCurrentDefine(pointer);
                HandleCurrent(_currentContent!);
                await DemonstrateFragments(_preparedFragments!);
            });

        //_machine.Configure(PersonState.Polling);
        //.OnEntryFromAsync(Trigger.PollAnswer, )

        _machine.OnUnhandledTriggerAsync((_, _) => Chat.SendAsync($"Произошла ошибка"));
    }

    #endregion Configuration

    // -------------------------------------------------------------------//

    #region Business logic variables

    private Person _person;
    private ContentPointer? _currentContent;
    private Condition? _cuurrentConditions;
    private List<(Coordinate coordinate, Stage stage)> _allowedPlaces = new();
    private List<(string label, ContentPointer pointer)> _allowedLinks = new();
    private Queue<(Fragment payload, int delay)> _preparedFragments = new();
    private Queue<List<string>> _keyboardButtons = new();

    #endregion Business logic variables

    #region Business logic

    private PersonState InitialDestinationStateSelector(Command cmd)
    {
        if (cmd.Name == "start" && !string.IsNullOrWhiteSpace(cmd.Arguments))
            return PersonState.Preparing;
        else
            return PersonState.Start;
    }

    // var args = cmd!.Arguments!.Split(':');
    //         return args[0] switch
    //         {
    //             "stage" => PersonState.StageHandling,
    //             "step" => PersonState.StepHandling,
    //             "route" => PersonState.RouteHandling,
    //             _ => PersonState.Start,
    //         };

    private void NewCurrentDefine(ContentPointer pointer)
    {
        switch (pointer.Type)
        {
            case ContentType.Route:
                _currentContent = new() { Route = pointer!.Route, Stage = pointer!.Route!.InitialStage, Type = ContentType.Route | ContentType.Stage };
                break;
            case ContentType.Stage:
                if (_currentContent?.Route is not null && _currentContent?.Stage is not null)
                {
                    var sequence = (from s in _repo.Sequences
                                    where s.AttachedRoute.Id == _currentContent!.Route.Id &&
                                        s.From.Id == _currentContent!.Stage.Id &&
                                        s.To.Id == pointer!.Stage!.Id
                                    select s).SingleOrDefault();
                    if (sequence is not null)
                        _currentContent = new() { Route = pointer!.Route, Stage = pointer!.Stage, Type = ContentType.Route | ContentType.Stage };
                    else
                        _currentContent = new() { Stage = pointer!.Stage, Type = ContentType.Stage };
                }
                else
                    _currentContent = new() { Stage = pointer!.Stage, Type = ContentType.Stage };
                break;
            case ContentType.Step:
                if (_currentContent?.Route is not null && _currentContent?.Stage is not null)
                {
                    var pointers = from sequence in _repo.Sequences
                                   join step in _repo.StepsInStage on sequence.To.Id equals step.AttachedStage.Id
                                   where sequence.AttachedRoute.Id == _currentContent!.Route.Id && step.Payload.Id == pointer!.Step!.Id
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
                        _currentContent = new() { Step = pointer!.Step, Type = ContentType.Step };
                }
                else
                    _currentContent = new() { Step = pointer!.Step, Type = ContentType.Step };
                break;
            case ContentType.Stage | ContentType.Step:
                if (_currentContent?.Route is not null && _currentContent?.Stage is not null)
                {
                    var pointers = from sequence in _repo.Sequences
                                   join step in _repo.StepsInStage on sequence.To equals step.AttachedStage
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
                    _currentContent = new() { Step = pointer!.Step, Type = ContentType.Step };
                break;
            case ContentType.Route | ContentType.Stage:
                throw new NotImplementedException();
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

    private void HandleCurrent(ContentPointer pointer)
    {
        _allowedLinks.Clear();
        _allowedPlaces.Clear();
        _preparedFragments.Clear();
        _keyboardButtons.Clear();
        //_cuurrentConditions = null;

        if (pointer.Type.HasFlag(ContentType.Stage) && _currentContent?.Stage is Stage stage)
        {
            HandleStage(stage, _currentContent?.Step);
            if (pointer.Type.HasFlag(ContentType.Route) && _currentContent?.Route is Route route)
            {
                var availableStages = (from s in _repo.Sequences
                                       where s.AttachedRoute.Id == route.Id && s.From.Id == stage.Id
                                       select s.To).ToList();

                var notPresent = new List<Stage>();
                foreach (var available in availableStages)
                    if (_allowedLinks.Find(l => l.pointer?.Stage?.Id == available!.Id).pointer is null) //todo:check
                        notPresent.Add(available);

                bool isLabelessSpot = false;
                bool isLabelessStage = false;
                foreach (var indirect in notPresent) //todo: внешний источник текста
                {
                    if (indirect.Location is Spot spot)
                    {
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

                        if (stage.Label is string stageLabel)
                            label = $"🔎 Расскажи про {stageLabel}";
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
        var orderedSteps = stage.Steps.OrderBy(s => s.Order);
        bool isStepReached = step is null;

        foreach (var s in orderedSteps ?? Enumerable.Empty<StepInStage>())
            if (isStepReached)
                HandleStep(s.Payload, s.Delay);
            else if (s.Id == step?.Id)
            {
                isStepReached = true;
                HandleStep(s.Payload, s.Delay);
            }
    }

    private void HandleStep(Step step, int delay)
    {
        if (FragmentDetermine(step) is Fragment fragment)
        {
            var keyboardLine = new List<string>();
            _preparedFragments.Enqueue((fragment, delay));
            foreach (var button in fragment?.Buttons ?? Enumerable.Empty<Button>())
                if (button.Type is ButtonType.InlineTransition or ButtonType.KeyboardTransition &&
                    button?.Label is string label && button?.Target?.Pointer is ContentPointer pointer)
                {
                    _allowedLinks.Add((label, pointer));
                    if (button.Type is ButtonType.KeyboardTransition)
                        keyboardLine.Append(label);
                }
            if (keyboardLine.Count > 0)
                _keyboardButtons.Enqueue(keyboardLine);
        }
    }

    private Fragment? FragmentDetermine(Step step) => step.Fragments.Find(f => f.Conditions == null); //todo: compare with current conditions

    private async Task DemonstrateFragments(Queue<(Fragment payload, int delay)> fragments)
    {
        while (fragments.TryDequeue(out var fragment))
        {
            switch (fragment.payload.Type)
            {
                case FragmentType.Text:
                case FragmentType.Media:
                    await Task.Delay(TimeSpan.FromSeconds(fragment.delay));
                    await Chat.SendAsync(fragment.payload);
                    break;
                case FragmentType.Timer:
                    if (fragment.payload.Timer!.Target.IsBinded)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(fragment.payload.Timer!.Delay));
                        await _machine.FireAsync<ContentPointer>(_contentTrigger, fragment.payload.Timer.Target.Pointer!);
                        return;
                    }
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
    public async Task SubmitAsync(Spot spot)
    {
        var submittedPosition = new Coordinate(spot.Latitude, spot.Longitude);
        var results = from loc in _allowedPlaces
                      let distanse = GeoCalculator.GetDistance(submittedPosition, loc.coordinate, distanceUnit: DistanceUnit.Meters)
                      where distanse <= 50 //todo: учесть погрешность 
                      orderby distanse
                      select loc.stage;
        if (results.Count() > 0)
            await _machine.FireAsync<ContentPointer>(_contentTrigger, new() { Stage = results.First(), Type = ContentType.Stage });
    }

    #endregion IChatBehaviour
}