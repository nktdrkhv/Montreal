using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types.InlineQueryResults;
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
    private readonly BotDbContext _context;

    public UpdateHandlerService(ILogger<UpdateHandlerService> logger, IUserRepository repo, BotDbContext context)
    {
        _logger = logger;
        _repo = repo;
        _context = context;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _ = Task.Run(async () =>
            {
                try
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
                            await HandleInlineQueryAsync(botClient, inline, cancellationToken);
                            break;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Exception during handling");
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

    public async Task HandleInlineQueryAsync(ITelegramBotClient bot, InlineQuery inlineQuery, CancellationToken ctn)
    {
        var routes = await _context.Routes.IgnoreAutoIncludes().ToListAsync();
        if (routes is not null)
        {
            List<InlineQueryResultArticle> articles = new();
            foreach (var route in routes)
            {
                InputTextMessageContent textMessageContent = new(route.Description!);
                InlineQueryResultArticle article = new(route.Name, route.Label!, textMessageContent);
                article.ReplyMarkup = new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Посмотреть", "https://t.me/yefim_bot"));
                article.ThumbUrl = "AgACAgIAAxkBAAIF6mNUsLXIqlO-oAlR_FKF_qImth1PAAJhvzEbL4aoSlN3_wJsC5UMAQADAgADeQADKgQ";
                article.Url = "https://t.me/yefim_bot";
                articles.Add(article);
            }
            await bot.AnswerInlineQueryAsync(inlineQuery.Id, articles, 5000, false);
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
