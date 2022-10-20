using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
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
        _ = Task.Run(async () =>
            {
                switch (update)
                {
                    case { Message: { } message }:
                        if (_repo.GetBehaviour(update, cancellationToken) is IChatBehaviour userByMessage)
                        {
                            userByMessage.Chat.Add(message);
                            await HandleMessageAsync(userByMessage, message);
                        }
                        break;
                    case { CallbackQuery: { } callback }:
                        if (_repo.GetBehaviour(update, cancellationToken) is IChatBehaviour userByCallback)
                        {
                            userByCallback.Chat.Add(callback);
                            await HandleCallbackQueryAsync(userByCallback, callback);
                        }
                        break;
                    case { InlineQuery: { } inline }:
                        await Task.CompletedTask;
                        break;
                }
            });
        await Task.CompletedTask;
    }

    public async Task HandleMessageAsync(IChatBehaviour user, Message message)
    {
        if (MessageHelper.ExtractCommand(message) is Command command)
            await user.SubmitAsync(command);
        else if (MessageHelper.ExtractText(message) is string text)
            await user.SubmitAsync(text);
        else if (MessageHelper.ExtractSpot(message) is Spot spot)
            await user.SubmitAsync(spot);
        else if (MessageHelper.ExtractMedia(message) is Media media)
            await user.SubmitAsync(media);
        else
            await Task.CompletedTask;
    }

    public async Task HandleCallbackQueryAsync(IChatBehaviour user, CallbackQuery callbackQuery)
    {
        if (CallbackQueryHelper.ExtractCommand(callbackQuery) is Command cmd)
            await user.SubmitAsync(cmd);
        else if (CallbackQueryHelper.ExtractText(callbackQuery) is string text)
            await user.SubmitAsync(text);
        else
            await Task.CompletedTask;
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
