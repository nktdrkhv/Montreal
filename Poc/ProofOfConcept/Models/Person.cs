using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Montreal.Bot.Poc.Models;

[Table("Person")]
[Index("TelegramIdentity", IsUnique = true, Name = "TelegramId")]
public class Person
{
    public int Id { get; set; }
    public long TelegramIdentity { get; set; } = default!;
    public string? FullName { get; set; }
    public List<Activity>? ActivityLog { get; set; }
}