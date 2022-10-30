using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Helpers;

public static class FileHelper
{
    public static void BackupFiles(ITelegramBotClient bot)
    {
        using var repo = new BotDbContext();
    }

    public static void RestoreFiles(ITelegramBotClient bot)
    {
        using var repo = new BotDbContext();
    }
}