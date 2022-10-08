using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface ITelegramChat
{
    ITelegramBotClient Bot { get; set; }
    User User { get; set; }
    Task<Message> SendAsync(Fragment fragment);
}