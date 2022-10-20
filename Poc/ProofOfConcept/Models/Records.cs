using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public record Command
{
    public string Name { get; set; } = default!;
    public string? Arguments { get; set; }
}

[Owned]
public record Media
{
    public MediaType Type { get; set; }
    public PhotoSize? Photo { get; set; }
    public Video? Video { get; set; }
    public VideoNote? VideoNote { get; set; }
    public Sound? Sound { get; set; }
    public Sticker? Sticker { get; set; }
    public string? Caption { get; set; }
}

[Owned]
public record Timer
{
    /// <summary>
    /// In seconds
    /// </summary>
    public int Delay { get; set; }
    public Target Target { get; set; } = default!;
}

[Owned]
public record ContentPointer
{
    public ContentType Type { get; set; } = ContentType.None;
    public Step? Step { get; set; }
    public Stage? Stage { get; set; }
    public Route? Route { get; set; }
}

[Owned]
public record Spot
{
    public double? Accuracy { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Label { get; set; }
    public string? Address { get; set; }
    public int? Number { get; set; }
}