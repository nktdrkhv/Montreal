using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure;

public class TelegramChat : ITelegramChat
{
    private ITelegramBotClient _bot;
    private User _user;
    private CancellationToken _ctn;

    public TelegramChat(ITelegramBotClient bot, User user, CancellationToken ctn)
    {
        _bot = bot;
        _user = user;
        _ctn = ctn;
    }

    public Task AddAsync(Message message) => throw new NotImplementedException();
    public Task AddAsync(CallbackQuery callback) => throw new NotImplementedException();

    public async Task<Message> SendAsync(Fragment fragment)
    {
        var action = fragment switch
        {
            { Text: { } text } => _bot.SendTextMessageAsync(_user.Id, text!),
        };
        return await action;
    }
    public async Task<Message> SendAsync(string text) => await _bot.SendTextMessageAsync(_user.Id, text, protectContent: true, cancellationToken: _ctn);
}