using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Helpers;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Services;

public class UpdateHandlerService : IUpdateHandler
{
    private readonly ILogger<UpdateHandlerService> _logger;
    private readonly IUserRepository _repo;

    public UpdateHandlerService(ILogger<UpdateHandlerService> logger, IUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var user = _repo.GetBehaviour(update, cancellationToken);
        if (user is null) return;

        try
        {
            var handler = update switch
            {
                { Message: { } message } => HandleMessageAsync(message),
                _ => Task.CompletedTask,
            };
            await handler;
        }
        catch (Exception e)
        {
            await HandlePollingErrorAsync(botClient, e, cancellationToken);
        }

        async Task HandleMessageAsync(Message message)
        {
            if (MessageHelper.ExtractCommand(message) is Command command)
                await user.SubmitAsync(command);
            else if (MessageHelper.ExtractText(message) is string text)
                await user.SubmitAsync(text);
        }
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
        _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);
        if (exception is RequestException)
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
    }
}
