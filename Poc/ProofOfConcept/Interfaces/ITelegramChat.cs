using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface ITelegramChat
{
    Task AddAsync(Message message);
    Task AddAsync(CallbackQuery callback);

    Task<Message> SendAsync(Fragment fragment);
    Task<Message> SendAsync(string text);
}