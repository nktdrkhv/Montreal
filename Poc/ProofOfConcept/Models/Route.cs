using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public record Route : ContentBase
{
    public Stage InitialStage { get; set; } = default!;
    public StageSequence[] Stages { get; set; } = default!;
}