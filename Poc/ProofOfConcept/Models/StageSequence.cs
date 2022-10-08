namespace Montreal.Bot.Poc.Models;

public record StageSequence
{
    public int Id { get; set; }
    public Stage FromStage { get; set; } = default!;
    public Stage ToStage { get; set; } = default!;
}