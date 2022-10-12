using Microsoft.Extensions.Logging;
using Stateless;
using Geolocation;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure.Behaviours;

public class PersonBehaviour : IChatBehaviour
{
    private ILogger<PersonBehaviour> _logger;
    public ITelegramChat _chat;
    private IAppRepository _repo;

    public PersonBehaviour(ITelegramChat chat, IAppRepository repo, ILogger<PersonBehaviour> logger)
    {
        _chat = chat;
        _repo = repo;
        _logger = logger;

        _machine = new StateMachine<PersonState, Trigger>(() => _state, s => _state = s);
        _textTrigger = _machine.SetTriggerParameters<string>(Trigger.Text);
        _commandTrigger = _machine.SetTriggerParameters<Command>(Trigger.Command);
        _targetTrigger = _machine.SetTriggerParameters<Target>(Trigger.Target);
        _fragmentTrigger = _machine.SetTriggerParameters<Fragment>(Trigger.Fragment);

        Configure();
    }

    private PersonState _state = PersonState.Initial;
    private StateMachine<PersonState, Trigger> _machine;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<string> _textTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<Target> _targetTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<Command> _commandTrigger;
    private StateMachine<PersonState, Trigger>.TriggerWithParameters<Fragment> _fragmentTrigger;

    public void Configure()
    {
        _machine.Configure(PersonState.Initial)
            .PermitIf<Command>(_commandTrigger, PersonState.Start, cmd => cmd.Name == "start")
            .OnExitAsync(() => _chat.SendAsync("Приветсвую!")); //TODO: проверка пользователя. Новый ли он.

        _machine.Configure(PersonState.Start)
            .OnEntryAsync(async () =>
            {
                var startStage = await _repo.GetStartStageAsync();

                var orderedSteps = startStage.Steps.OrderBy(s => s.Order);
                foreach (var step in orderedSteps)
                {
                    await _chat.SendAsync(step.Payload.Fragments.First());
                }
            });

        _machine.OnUnhandledTriggerAsync((_, _) => _chat.SendAsync("Произошла ошибка"));
    }

    private List<(Coordinate, Target)>? _targets;
    private List<(string link, Target target)>? _buttonsLinks;

    public async Task SubmitAsync(string text)
    {
        var target = _buttonsLinks?.Find(button => button.link == text).target;
        if (target is not null)
            await _machine.FireAsync<Target>(_targetTrigger, target); // выделено отдельно с целью уточнения Command
        else
            await _machine.FireAsync<string>(_textTrigger, text);
    }
    public async Task SubmitAsync(Command command) => await _machine.FireAsync<Command>(_commandTrigger, command);
    public async Task SubmitAsync(Fragment fragment) => await _machine.FireAsync<Fragment>(_fragmentTrigger, fragment);
}