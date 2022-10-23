using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public class Media
{
    public string Id { get; set; } = Guid.NewGuid().ToString()[..7];
    public MediaType Type { get; set; }
    public PhotoSize? Photo { get; set; }
    public Video? Video { get; set; }
    public VideoNote? VideoNote { get; set; }
    public Sound? Sound { get; set; }
    public Sticker? Sticker { get; set; }
    public string? Caption { get; set; }
}