using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Hangfire;
using Hangfire.Storage.SQLite;
using Montreal.Bot.Poc.Services;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSystemd()
    .ConfigureServices((context, services) =>
    {
        services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage(Path.Combine("Files", "DataBases", "Schedule.db")));
        services.AddHangfireServer();

        services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    TelegramBotClientOptions options = new(context.Configuration["Telegram:Token"]);
                    return new TelegramBotClient(options, httpClient);
                });

        UserRepositoryService.Secret = context.Configuration["Secrets:Maker"];

        services.AddDbContext<BotDbContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Scoped);
        services.AddScoped<IUserRepository, UserRepositoryService>();
        services.AddScoped<UpdateHandlerService>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();
    })
    .Build();

SeedData.DoWork();

host.Services.GetService<IBackgroundJobClient>();
RecurringJob.AddOrUpdate("clearing-cached-users", () => UserRepositoryService.ForgetOfflineUsers(), "*/30 * * * *");

await host.RunAsync();
