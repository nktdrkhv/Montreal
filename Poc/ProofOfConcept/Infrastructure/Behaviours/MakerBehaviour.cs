using Stateless;
using Microsoft.Extensions.Logging;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure.Behaviours;

public class MakerBehaviour : IChatBehaviour
{
    private ITelegramChat _chat;
    private IAppRepository _repo;
    private ILogger<MakerBehaviour> _logger;

    public MakerBehaviour(ITelegramChat chat, IAppRepository repo, ILogger<MakerBehaviour> logger)
    {
        _chat = chat;
        _repo = repo;
        _logger = logger;

        _machine = new StateMachine<MakerState, Trigger>(() => _state, s => _state = s);
        _textTrigger = _machine.SetTriggerParameters<string>(Trigger.Text);
        _commandTrigger = _machine.SetTriggerParameters<Command>(Trigger.Command);
        _fragmentTrigger = _machine.SetTriggerParameters<Fragment>(Trigger.Fragment);

        Configure();
    }

    private MakerState _state = MakerState.Initial;
    private StateMachine<MakerState, Trigger> _machine;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<string> _textTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Command> _commandTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Fragment> _fragmentTrigger;

    private void Configure()
    {
        _machine.Configure(MakerState.Initial)
            .PermitIf<Command>(_commandTrigger, MakerState.Base, cmd => cmd.Name == "start");

        _machine.Configure(MakerState.Base)
            .PermitIf<Command>(_commandTrigger, MakerState.StepCreation, cmd => cmd.Name == "step")
            .PermitIf<Command>(_commandTrigger, MakerState.StageCreation, cmd => cmd.Name == "stage")
            .PermitIf<Command>(_commandTrigger, MakerState.RouteCreation, cmd => cmd.Name == "route");

        _machine.Configure(MakerState.StepCreation)
            .PermitIf<Command>(_commandTrigger, MakerState.Base, cmd => cmd.Name == "submit")
            .Permit(Trigger.Fragment, MakerState.FragmentCreation)
            .InternalTransitionAsync<Command>(_commandTrigger, (cmd, _) => Task.CompletedTask);

        _machine.Configure(MakerState.FragmentCreation);



    }

    public Task SubmitAsync(string text) => throw new NotImplementedException();
    public Task SubmitAsync(Command command) => throw new NotImplementedException();
    public Task SubmitAsync(Fragment fragment) => throw new NotImplementedException();
}