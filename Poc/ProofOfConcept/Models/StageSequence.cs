using System.ComponentModel.DataAnnotations.Schema;

namespace Montreal.Bot.Poc.Models;

[Table("StageSequence")]
public class StageSequence
{
    public int Id { get; set; }
    public Route AttachedRoute { get; set; } = default!;
    public Stage From { get; set; } = default!;
    public Stage To { get; set; } = default!;
}