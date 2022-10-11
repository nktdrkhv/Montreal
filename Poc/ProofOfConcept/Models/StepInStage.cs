namespace Montreal.Bot.Poc.Models;

public record StepInStage
{
    public int Id { get; set; }
    public Stage AttachedStage { get; set; } = default!;
    public Step Payload { get; set; } = default!;
    public int Order { get; set; }
    public int Delay { get; set; }
}