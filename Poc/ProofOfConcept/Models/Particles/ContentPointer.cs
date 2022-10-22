using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public class ContentPointer
{
    public int Id { get; set; }
    public ContentType Type { get; set; } = ContentType.None;

    public int? StepId { get; set; }
    public int? StageId { get; set; }
    public int? RouteId { get; set; }

    [ForeignKey("StepId")]
    public Step? Step { get; set; }
    [ForeignKey("StageId")]
    public Stage? Stage { get; set; }
    [ForeignKey("RouteId")]
    public Route? Route { get; set; }
}