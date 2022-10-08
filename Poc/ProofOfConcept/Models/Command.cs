namespace Montreal.Bot.Poc.Models;

public record Command
{
    public string Label { get; set; } = default!;
    public string[]? Arguments { get; set; }
}