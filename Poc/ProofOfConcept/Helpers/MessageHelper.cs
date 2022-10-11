using Telegram.Bot.Types;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Helpers;

public static class MessageHelper
{
    public static Command? ExtractCommand(Message message)
    {
        var parts = message?.Text?.Split(' ')[0];
        return parts switch
        {
            "/start" => new Command("start", parts[1..]),
            _ => null
        };
    }

    public static string? ExtractText(Message message) => message?.Text;
}