using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

[Table("Fragment")]
public class Fragment
{
    public int Id { get; set; }
    public FragmentType Type { get; set; }

    public string? Text { get; set; }
    public Timer? Timer { get; set; }
    public Spot? Location { get; set; }
    public List<Media>? Media { get; set; }

    public List<Button>? Buttons { get; set; }
    public Condition? Conditions { get; set; }
    public bool Pin { get; set; } = false;
}