using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Helpers;

public static class CallbackQueryHelper
{
    public static Command? ExtractCommand(CallbackQuery callback)
    {
        var data = callback.Data?.Split(' ');
        if (data?.Length == 2)
            return data[0] switch
            {
                "replace" => new Command() { Name = "replace", Arguments = data[1] },
                _ => null
            };
        else
            return null;
    }
    public static string? ExtractText(CallbackQuery callback) => callback?.Data;
}