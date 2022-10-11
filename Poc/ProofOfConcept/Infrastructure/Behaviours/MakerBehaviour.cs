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
        _mediaTrigger = _machine.SetTriggerParameters<Fragment>(Trigger.Fragment);

        Configure();
    }

    private MakerState _state = MakerState.Initial;
    private StateMachine<MakerState, Trigger> _machine;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<string> _textTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Command> _commandTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Fragment> _mediaTrigger;

    private void Configure()
    {
    }

    public Task SubmitAsync(string text) => throw new NotImplementedException();
    public Task SubmitAsync(Command command) => throw new NotImplementedException();
    public Task SubmitAsync(Fragment fragment) => throw new NotImplementedException();
}