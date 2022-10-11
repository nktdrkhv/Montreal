using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Abstract;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public record Stage : ContentBase
{
    [Column("StageType")]
    public StageType Type { get; set; }
    public StepInStage[] Steps { get; set; } = default!;
    public Location? Coordinate { get; set; }
}