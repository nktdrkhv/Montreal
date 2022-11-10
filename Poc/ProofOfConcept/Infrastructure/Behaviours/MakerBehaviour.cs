using Stateless;
using Hangfire;
using Microsoft.Extensions.Logging;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Helpers;

namespace Montreal.Bot.Poc.Infrastructure.Behaviours;

public class MakerBehaviour : IChatBehaviour
{
    public ITelegramChat Chat { get; set; }
    // private IAppRepository _repo;
    private ILogger<MakerBehaviour> _logger;

    public MakerBehaviour(ITelegramChat chat,/* IAppRepository repo,*/ ILogger<MakerBehaviour> logger)
    {
        Chat = chat;
        //_repo = repo;
        _logger = logger;

        _machine = new StateMachine<MakerState, Trigger>(() => _state, s => _state = s);
        _textTrigger = _machine.SetTriggerParameters<string>(Trigger.Text);
        _commandTrigger = _machine.SetTriggerParameters<Command>(Trigger.Command);

        //Configure();
    }

    private MakerState _state = MakerState.Initial;
    private StateMachine<MakerState, Trigger> _machine;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<string> _textTrigger;
    private StateMachine<MakerState, Trigger>.TriggerWithParameters<Command> _commandTrigger;

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
            //.Permit(Trigger.Fragment, MakerState.FragmentCreation)
            .InternalTransitionAsync<Command>(_commandTrigger, (cmd, _) => Task.CompletedTask);

        _machine.Configure(MakerState.FragmentCreation);
    }

    public async Task SubmitAsync(string text)
    {
        if (text == "backup")
        {
            FileHelper.BackupFiles(Chat.Bot);
        }
        else if (text == "clear")
            RecurringJob.TriggerJob("clearing-cached-users");
        else
            await Chat.SendAsync($"_Неподдерживаемый тип_");
    }
    public async Task SubmitAsync(Command command) => await Chat.SendAsync($"_Неподдерживаемый тип_");
    public async Task SubmitAsync(Media media)
    {
        var handler = media.Type switch
        {
            MediaType.Photo => Chat.SendAsync($"*Фото:*\n`{media.Photo!.FileId}`"),
            MediaType.Sound => Chat.SendAsync($"*Звук*\n`{media?.Sound?.Audio?.FileId ?? media?.Sound?.Voice?.FileId}`"),
            MediaType.Sticker => Chat.SendAsync($"*Стикер*\n`{media?.Sticker?.FileId}`"),
            _ => Chat.SendAsync($"_Неподдерживаемый тип_")
        };
        await handler;
    }
    public async Task SubmitAsync(Spot spot) => await Chat.SendAsync($"_Неподдерживаемый тип_");

    public void Dispose() { }
}