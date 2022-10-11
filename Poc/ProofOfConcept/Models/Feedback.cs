using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

[Table("Feedback")]
public record Feedback
{
    public int Id { get; set; }
    public User Person { get; set; } = default!;
    public Target Cause { get; set; } = default!;
    public Fragment[] Payload { get; set; } = default!;
}