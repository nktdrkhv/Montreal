using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

[Table("Fragment")]
public record Fragment
{
    public int Id { get; set; }
    public FragmentType Type { get; set; }
    public Condition Conditions { get; set; }

    public string? Text { get; set; }
    public PhotoSize? Photo { get; set; }
    public Video? Video { get; set; }
    public VideoNote? VideoNote { get; set; }
    public Sound? Sound { get; set; }
    public Sticker? Sticker { get; set; }
    public Location? Location { get; set; }

    public Timer? Timer { get; set; }
    public Button[]? Buttons { get; set; }
}