using Telegram.Bot.Types;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure;

public class TelegramChat : ITelegramChat
{
    public User User { get; set; }
    public Task<Message> SendAsync(Fragment fragment) => throw new NotImplementedException();

    public TelegramChat(User user)
    {
        User = user;
    }
}