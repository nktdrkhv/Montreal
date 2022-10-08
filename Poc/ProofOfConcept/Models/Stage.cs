using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public record Stage : ContentBase
{
    [Column("StageType")]
    public StageType Type { get; set; }
    public StepOrder[] Steps { get; set; } = default!;
    public Location? Coordinate { get; set; }
}