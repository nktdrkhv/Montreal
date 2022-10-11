using Telegram.Bot;
using Telegram.Bot.Types;

namespace Montreal.Bot.Poc.Interfaces;

public interface IUserRepository
{
    IChatBehaviour? GetBehaviour(Update update, CancellationToken ctn);
}