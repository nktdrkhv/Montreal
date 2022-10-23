using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
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
    private static string _secret = "add"; //Guid.NewGuid().ToString()[0..7];
    private static ConcurrentDictionary<long, IChatBehaviour> _cachedUsers = new();

    private IAppRepository _repo;
    private ILogger<UserRepositoryService> _logger;
    private IServiceProvider _provider;

    public UserRepositoryService(IAppRepository appRepository, IServiceProvider serviceProvider, ILogger<UserRepositoryService> logger)
    {
        _repo = appRepository;
        _provider = serviceProvider;
        _logger = logger;

        _logger.LogInformation($"Maker secret is [{_secret}]");
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
            _logger.LogInformation($"User [{id}] restored from cache");
            if (update.Message?.Text?.StartsWith("/forget") is true)
            {
                _cachedUsers.TryRemove(id, out var _);
                _logger.LogInformation($"User [{id}] is forgotten");
                return null;
            }
            else
                return cachedUser;
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
                    _provider.GetRequiredService<IAppRepository>(),
                    _provider.GetRequiredService<ILogger<MakerBehaviour>>()),
                false or null => new PersonBehaviour(
                    _repo.GetPerson(id),
                    telegramChat,
                    //_provider.GetRequiredService<IAppRepository>(),
                    _provider.GetRequiredService<ILogger<PersonBehaviour>>()),
            };

            _logger.LogInformation($"User [{id} = {user.Username ?? "without nickname"}] 's behaviour is created");

            if (_cachedUsers.TryAdd(id, behaviour))
                return behaviour;
            else
                return null;
        }
    }
}