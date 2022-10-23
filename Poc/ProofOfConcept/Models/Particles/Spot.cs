using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

public class Spot
{
    public string Id { get; set; } = Guid.NewGuid().ToString()[..7];
    public double? Accuracy { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Label { get; set; }
    public string? Address { get; set; }
    public int? Number { get; set; }
}