using System.ComponentModel.DataAnnotations.Schema;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

[Table("Activity")]
public class Activity
{
    public int Id { get; set; }
    public Person Performer { get; set; } = default!;
    public ContentPointer Pointer { get; set; } = default!;
    public long CurrentTime { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();
    public Condition Contitions { get; set; }
}