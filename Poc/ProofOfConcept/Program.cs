﻿using Microsoft.Extensions.DependencyInjection;
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

        services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    //TelegramBotClientOptions options = new(context.Configuration["Telegram:ApiToken"]);
                    TelegramBotClientOptions options = new("5433978144:AAGGHlGLYfGu5jlS-XirVzEHEAfy-sPYSy0");
                    return new TelegramBotClient(options, httpClient);
                });

        services.AddDbContext<BotDbContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Scoped);
        services.AddScoped<IUserRepository, UserRepositoryService>();
        services.AddScoped<UpdateHandlerService>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();
    })
    .Build();

SeedData.DoWork();

await host.RunAsync();
