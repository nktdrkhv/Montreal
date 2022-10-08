using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Montreal.Bot.Poc.Services;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<BotDbContext>();

        services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    TelegramBotClientOptions options = new(context.Configuration["Telegram:ApiToken"]);
                    return new TelegramBotClient(options, httpClient);
                });

        services.AddScoped<IUserRepository, UserRepositoryService>();
        services.AddScoped<UpdateHandlerService>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();
    })
    .Build();

await host.RunAsync();
