using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        services.AddLogging(lb =>
        {
            lb.ClearProviders();
            lb.AddConsole();
        });
        services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage(Path.Combine("Files", "DataBases", "Schedule.db")));
        services.AddHangfireServer();

        services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    //TelegramBotClientOptions options = new(context.Configuration["Telegram:Token"]);
                    TelegramBotClientOptions options = new("5433978144:AAGGHlGLYfGu5jlS-XirVzEHEAfy-sPYSy0");
                    return new TelegramBotClient(options, httpClient);
                });

        UserRepositoryService.Secret = "d2ec9f2c";

        services.AddDbContext<BotDbContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Scoped);
        services.AddScoped<IUserRepository, UserRepositoryService>();
        services.AddScoped<UpdateHandlerService>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();
    })
    .Build();

SeedData.DoWork();

//GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(host.Services));
host.Services.GetService<IBackgroundJobClient>();
// RecurringJob.AddOrUpdate<IServiceProvider>("clearing-cached-users", (IServiceProvider sp) => UserRepositoryService.ForgetOfflineUsers(sp), Cron.Minutely);
// //"*/30 * * * *"

RecurringJob.AddOrUpdate("clearing-cached-users", () => UserRepositoryService.ForgetOfflineUsers(), "*/30 * * * *");

await host.RunAsync();