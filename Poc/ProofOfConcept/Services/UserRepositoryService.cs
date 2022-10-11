using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Infrastructure;
using Montreal.Bot.Poc.Infrastructure.Behaviours;
using Montreal.Bot.Poc.Helpers;

namespace Montreal.Bot.Poc.Services;

public class UserRepositoryService : IUserRepository
{
    private static string _secret = "gomaker";

    private static ConcurrentDictionary<long, IChatBehaviour> _cachedUsers = new();
    private ILogger<UserRepositoryService> _logger;
    private IServiceProvider _provider;

    public UserRepositoryService(IServiceProvider serviceProvider, ILogger<UserRepositoryService> logger)
    {
        _provider = serviceProvider;
        _logger = logger;
    }

    public IChatBehaviour? GetBehaviour(Update update, CancellationToken ctn)
    {
        var id = UpdateHelper.ExtractUserId(update);

        if (id == 0)
        {
            _logger.LogInformation($"Update [{update.Id}] was ignored");
            return null;
        }

        var isExist = _cachedUsers.TryGetValue(id, out var cachedUser);
        if (isExist)
        {
            _logger.LogInformation($"User [{id}] restored from cache");
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
                    telegramChat,
                    _provider.GetRequiredService<IAppRepository>(),
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