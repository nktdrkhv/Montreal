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

    private Stack<Message> _recievedMessages = new();
    private Stack<CallbackQuery> _recievedCallbacks = new();

    public void Add(Message message) => _recievedMessages.Append(message);
    public void Add(CallbackQuery callback) => _recievedCallbacks.Append(callback);

    public async Task<Message> SendAsync(Fragment fragment)
    {
        var action = fragment switch
        {
            { Text: { } text } => _bot.SendTextMessageAsync(_user.Id, text!),
            _ => throw new ArgumentException(),
        };
        return await action;
    }
    public async Task<Message> SendAsync(string text) => await _bot.SendTextMessageAsync(_user.Id, text, cancellationToken: _ctn);
}