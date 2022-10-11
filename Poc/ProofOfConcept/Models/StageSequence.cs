namespace Montreal.Bot.Poc.Models;

public record StageSequence
{
    public int Id { get; set; }
    public Stage From { get; set; } = default!;
    public Stage To { get; set; } = default!;
}