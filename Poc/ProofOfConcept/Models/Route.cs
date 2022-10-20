using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public class Route : ContentBase
{
    public Stage InitialStage { get; set; } = default!;
    public List<StageSequence> Stages { get; set; } = default!;
}