using Microsoft.EntityFrameworkCore;

namespace Montreal.Bot.Poc.Abstract;

[Index("Name", IsUnique = true, Name = "Name")]
public abstract class ContentBase
{
    public int Id { get; set; }
    public string Name { get; set; } = Guid.NewGuid().ToString()[0..7];
    public string? Label { get; set; }
    public string? Description { get; set; }
}