using System.ComponentModel.DataAnnotations.Schema;

namespace Montreal.Bot.Poc.Models;

[Table("Target")]
public class Target
{
    public int Id { get; set; }

    public bool IsBinded { get; set; } = false;

    /// <summary>
    /// In format: route:name_1:stage:name_2:step:name_3
    /// </summary>
    public string? Name { get; set; }
    public ContentPointer? Pointer { get; set; }
}