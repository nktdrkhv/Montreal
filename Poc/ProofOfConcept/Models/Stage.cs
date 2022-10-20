using System.ComponentModel.DataAnnotations.Schema;
using Montreal.Bot.Poc.Abstract;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public class Stage : ContentBase
{
    [Column("StageType")]
    public StageType Type { get; set; }
    public List<StepInStage> Steps { get; set; } = default!;
    public Spot? Location { get; set; }
}