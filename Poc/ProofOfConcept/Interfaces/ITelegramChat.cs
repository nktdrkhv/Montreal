using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface ITelegramChat
{
    void Add(Message message);
    void Add(CallbackQuery callback);

    Task<Message> SendAsync(Fragment fragment, Queue<List<string>>? uniteKeyboard = null, bool clearReplyMarkup = false);
    Task<Message> SendAsync(string text);
    Task SendAsync(Spot spot);

    Task SendAndDeleteAsync(string text, int delay);
    Task SendStatusAsync(ChatAction action = ChatAction.Typing);

    Task EditAsync(Fragment fragment, string uniqueId);

    Task DeleteRecievedMessageAsync();
    Task ClearMessageButtons();
}