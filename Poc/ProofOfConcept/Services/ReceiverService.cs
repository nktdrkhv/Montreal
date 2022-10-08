using Microsoft.Extensions.Logging;
using Montreal.Bot.Poc.Abstract;
using Telegram.Bot;

namespace Montreal.Bot.Poc.Services;

public class ReceiverService : ReceiverServiceBase<UpdateHandlerService>
{
    public ReceiverService(
        ITelegramBotClient botClient,
        UpdateHandlerService updateHandler,
        ILogger<ReceiverServiceBase<UpdateHandlerService>> logger)
        : base(botClient, updateHandler, logger)
    {
    }
}
