using System.Configuration;
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

    private static ConcurrentDictionary<long, CachedUser> _cachedUsers = new();

    public static string Secret = default!;
    public static void ForgetOfflineUsers()
    {
        // var scope = serviceProvider.CreateScope();
        // var logger = scope.ServiceProvider.GetService<ILogger<UserRepositoryService>>();
        Console.WriteLine("Starting of clearing");
        var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        foreach (var elem in _cachedUsers)
            if (now - elem.Value.LastActivityInUnixTime > 2700)
                if (_cachedUsers.TryRemove(elem.Key, out var cachedUser))
                {
                    cachedUser.ChatBehaviour.Dispose();
                    //logger?.LogInformation($"User [{cachedUser.ChatBehaviour.Chat.Me()}] is forgotten");
                    Console.WriteLine($"User [{cachedUser.ChatBehaviour.Chat.Me()}] is forgotten");
                }
    }

    private ILogger<UserRepositoryService> _logger;
    private IServiceProvider _provider;

    public UserRepositoryService(IServiceProvider serviceProvider, ILogger<UserRepositoryService> logger)
    {
        _provider = serviceProvider;
        _logger = logger;
        _logger.LogInformation($"Maker secret is [{Secret}]");
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
            _logger.LogInformation($"User [{id}]. Update [{update.Id}] is [{update.Type}]");
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

            IChatBehaviour behaviour = update.Message?.Text?.StartsWith($"/start {Secret}") switch
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

            _logger.LogInformation($"User [{id} = {user.Username ?? "without a nickname"}] 's behaviour is created");

            if (_cachedUsers.TryAdd(id, new() { ChatBehaviour = behaviour, LastActivityInUnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() }))
                return behaviour;
            else
                return null;
        }
    }
}