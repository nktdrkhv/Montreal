using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Infrastructure;
using Montreal.Bot.Poc.Infrastructure.Behaviours;
using Montreal.Bot.Poc.Helpers;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Services;

public class UserRepositoryService : IUserRepository
{
    private class CachedUser
    {
        public long LastActivityInUnixTime { get; set; }
        public IChatBehaviour ChatBehaviour { get; set; } = default!;
        //slim semaphore
    }

    private static string _secret = "add"; //Guid.NewGuid().ToString()[0..7];
    private static ConcurrentDictionary<long, CachedUser> _cachedUsers = new();

    //static UserRepositoryService() => BackgroundJob.Schedule(() => ForgetOfflineUsers(), TimeSpan.FromMinutes(30));

    private static void ForgetOfflineUsers()
    {
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        foreach (var elem in _cachedUsers)
            if (elem.Value.LastActivityInUnixTime - now > 2700)
                if (_cachedUsers.TryRemove(elem.Key, out var cachedUser))
                    cachedUser.ChatBehaviour.Dispose();
    }

    private ILogger<UserRepositoryService> _logger;
    private IServiceProvider _provider;

    public UserRepositoryService(IServiceProvider serviceProvider, ILogger<UserRepositoryService> logger)
    {
        _provider = serviceProvider;
        _logger = logger;
        _logger.LogInformation($"Maker secret is [{_secret}]");
    }

    public Person GetPerson(long telegramId)
    {
        using var context = new BotDbContext();
        var person = context.People.Where(p => p.TelegramIdentity == telegramId).SingleOrDefault();
        if (person is null)
        {
            person = new Person() { TelegramIdentity = telegramId };
            context.People.Add(person);
            context.SaveChanges();
        }
        return person;
    }

    public IChatBehaviour? GetBehaviour(Update update, CancellationToken ctn)
    {
        var id = UpdateHelper.ExtractUserId(update);

        if (id == 0)
        {
            _logger.LogInformation($"Update [{update.Id}] was ignored");
            return null;
        }

        if (_cachedUsers.TryGetValue(id, out var cachedUser))
        {
            _logger.LogInformation($"User [{id}] restored. Update [{update.Id}] is [{update.Type}]");
            if (update.Message?.Text?.StartsWith("/forget") is true && _cachedUsers.TryRemove(id, out var removedUser))
            {
                removedUser.ChatBehaviour.Dispose();
                _logger.LogInformation($"User [{id}] is forgotten");
                return null;
            }
            else
            {
                cachedUser.LastActivityInUnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                return cachedUser.ChatBehaviour;
            }
        }
        else
        {
            _logger.LogInformation($"User [{id}] 's behaviour is creating");

            var user = UpdateHelper.ExtractUser(update);
            if (user is null) return null;

            ITelegramChat telegramChat = new TelegramChat(
                _provider.GetRequiredService<ITelegramBotClient>(),
                user!, ctn);

            IChatBehaviour behaviour = update.Message?.Text?.StartsWith($"/start {_secret}") switch
            {
                true => new MakerBehaviour(
                    telegramChat,
                    /*_provider.GetRequiredService<IAppRepository>(),*/
                    _provider.GetRequiredService<ILogger<MakerBehaviour>>()),
                false or null => new PersonBehaviour(
                    GetPerson(id),
                    telegramChat,
                    //_provider.GetRequiredService<IAppRepository>(),
                    _provider.GetRequiredService<ILogger<PersonBehaviour>>()),
            };

            _logger.LogInformation($"User [{id} = {user.Username ?? "without nickname"}] 's behaviour is created");

            if (_cachedUsers.TryAdd(id, new() { ChatBehaviour = behaviour, LastActivityInUnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() }))
                return behaviour;
            else
                return null;
        }
    }
}