using System.Collections.Concurrent;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Interfaces;

namespace Montreal.Bot.Poc.Services;

public class AppRepositoryService : IAppRepository
{
    private BotDbContext _context;
    private static ConcurrentDictionary<long, IChatBehaviour> _cachedUsers = new();

    public AppRepositoryService(BotDbContext context)
    {
        _context = context;
    }
}