using System.ComponentModel.DataAnnotations.Schema;

namespace Montreal.Bot.Poc.Models;

[Table("Feedback")]
public class Feedback
{
    public int Id { get; set; }
    public Person Person { get; set; } = default!;
    public ContentPointer Cause { get; set; } = default!;
    public List<Fragment> Payload { get; set; } = default!;
}