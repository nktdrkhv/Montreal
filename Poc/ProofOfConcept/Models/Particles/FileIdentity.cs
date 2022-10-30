using System.ComponentModel.DataAnnotations.Schema;
using Telegram.Bot.Types;

namespace Montreal.Bot.Poc.Models;

[Table("FileIdentity")]
public class FileIdentity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LocalPath { get; set; } = default!;
    public string TelegramFileId { get; set; } = default!;
    public string TelegramBot { get; set; } = default!;
}