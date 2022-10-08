using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Logging;
using Montreal.Bot.Poc.Interfaces;

namespace Montreal.Bot.Poc.Abstract;

public abstract class ReceiverServiceBase<TUpdateHandler> : IReceiverService
    where TUpdateHandler : IUpdateHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly IUpdateHandler _updateHandlers;
    private readonly ILogger<ReceiverServiceBase<TUpdateHandler>> _logger;

    public ReceiverServiceBase(
        ITelegramBotClient botClient,
        TUpdateHandler updateHandler,
        ILogger<ReceiverServiceBase<TUpdateHandler>> logger)
    {
        _botClient = botClient;
        _updateHandlers = updateHandler;
        _logger = logger;
    }

    public async Task ReceiveAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions()
        {
            AllowedUpdates = Array.Empty<UpdateType>(),
            ThrowPendingUpdates = true,
        };

        var me = await _botClient.GetMeAsync(stoppingToken);
        _logger.LogTrace("Start receiving updates for {BotName}", me.Username ?? "Montreal Bot");

        await _botClient.ReceiveAsync(
            updateHandler: _updateHandlers,
            receiverOptions: receiverOptions,
            cancellationToken: stoppingToken);
    }
}
