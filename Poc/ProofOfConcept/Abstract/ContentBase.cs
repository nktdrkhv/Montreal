using Microsoft.EntityFrameworkCore;

namespace Montreal.Bot.Poc.Abstract;

[Index("Name", IsUnique = true, Name = "Name")]
public abstract record ContentBase
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Label { get; set; } = default!;
    public string? Description { get; set; }
}