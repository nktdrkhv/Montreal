using System.Collections.Concurrent;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Interfaces;

namespace Montreal.Bot.Poc.Services;

public class UserRepositoryService : IUserRepository
{
    private BotDbContext _context;
    private static ConcurrentDictionary<long, (IChatBehaviour behaviour, object locker)> _cachedUsers = new();

    public UserRepositoryService(BotDbContext context)
    {
        _context = context;
    }

    public Task<(IChatBehaviour behaviour, object locker)?> GetUser(long id) => throw new NotImplementedException();
}