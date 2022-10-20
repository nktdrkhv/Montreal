using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface ITelegramChat
{
    void Add(Message message);
    void Add(CallbackQuery callback);

    Task<Message> SendAsync(Fragment fragment);
    Task<Message> SendAsync(string text);
}