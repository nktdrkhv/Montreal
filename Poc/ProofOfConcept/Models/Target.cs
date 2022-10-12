using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public record Target
{
    public int Id { get; set; }
    public TargetType Type;
    public string Name = default!;

    // public Step? Step { get; set; }
    // public Stage? Stage { get; set; }
    // public Route? Route { get; set; }
}