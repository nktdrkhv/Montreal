using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;

namespace Montreal.Bot.Poc.Models;

[Table("Sound")]
public record Sound
{
    public int Id { get; set; }
    public Voice? Voice { get; set; }
    public Audio? Audio { get; set; }
    public string? Transcript { get; set; }
}