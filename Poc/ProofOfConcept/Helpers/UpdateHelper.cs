using Telegram.Bot.Types;

namespace Montreal.Bot.Poc.Helpers;

public static class UpdateHelper
{
    public static long ExtractUserId(Update update)
    {
        return update switch
        {
            { Message: { From: { Id: { } Id } } } => Id,
            { CallbackQuery: { From: { Id: { } Id } } } => Id,
            _ => (long)0,
        };
    }

    public static User? ExtractUser(Update update)
    {
        return update switch
        {
            { Message: { From: { } From } } => From,
            { CallbackQuery: { From: { } From } } => From,
            _ => null,
        };
    }
}