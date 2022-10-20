using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface IChatBehaviour
{
    ITelegramChat Chat { get; set; }
    Task SubmitAsync(string text);
    Task SubmitAsync(Command command);
    Task SubmitAsync(Media media);
    Task SubmitAsync(Spot spot);
}