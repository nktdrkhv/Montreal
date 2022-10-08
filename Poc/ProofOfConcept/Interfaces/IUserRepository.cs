namespace Montreal.Bot.Poc.Interfaces;

public interface IUserRepository
{
    Task<(IChatBehaviour behaviour, object locker)?> GetUser(long id);
}