namespace Montreal.Bot.Poc.Models;

public record StepOrder
{
    public int Id { get; set; }
    public Stage TargetStage { get; set; } = default!;
    public Step CurrentStep { get; set; } = default!;
    public int Order { get; set; }
    public int Delay { get; set; }
}