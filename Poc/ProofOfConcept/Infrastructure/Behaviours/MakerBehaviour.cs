using Stateless;
using Geolocation;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure;

public class MakerBehaviour : IChatBehaviour
{
    public ITelegramChat _chat;
    private IAppRepository _repo;

    public MakerBehaviour(ITelegramChat chat, IAppRepository repo)
    {
        _chat = chat;
        _repo = repo;

        _machine = new StateMachine<MakerState, Trigger>(() => _state, s => _state = s);
        _textTrigger = _machine.SetTriggerParameters<string>(Trigger.Text);
        _commandTrigger = _machine.SetTriggerParameters<Command>(Trigger.Command);
        _mediaTrigger = _machine.SetTriggerParameters<Fragment>(Trigger.Media);

        Configure();
    }

    private MakerState _state = MakerState.Initial;
    private StateMachine<MakerState, Trigger> _machine;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<string> _textTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Command> _commandTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Fragment> _mediaTrigger;

    private void Configure()
    {
        _machine = new StateMachine<MakerState, Trigger>(() => _state, s => _state = s);

        _machine.Configure(MakerState.Initial)
            .PermitIf<Command>(_commandTrigger, MakerState.Initial, cmd => cmd.Label == "w");
        //.Ignore(_mediaTrigger);


    }

    public Task SubmitAsync(string text) => throw new NotImplementedException();
    public Task SubmitAsync(Command command) => throw new NotImplementedException();
    public Task SubmitAsync(Fragment fragment) => throw new NotImplementedException();
}