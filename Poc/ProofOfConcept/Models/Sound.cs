using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

[Table("Sound")]
public class Sound
{
    public int Id { get; set; }
    public SoundType Type { get; set; }
    public Voice? Voice { get; set; }
    public Audio? Audio { get; set; }
    public string? Transcription { get; set; }
}