using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public record Command
{
    public string Name { get; set; } = default!;
    public string? Arguments { get; set; }
}

public record SentMessage(FragmentType fragmentType, MediaType? mediaType, int message);

[Owned]
public record Timer
{
    /// <summary>
    /// In seconds
    /// </summary>
    public int Delay { get; set; }
    public Target? Target { get; set; }
}