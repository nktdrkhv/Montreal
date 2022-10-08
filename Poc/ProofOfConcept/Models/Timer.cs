namespace Montreal.Bot.Poc.Models;

public record Timer
{
    public int Id { get; set; }
    public int Seconds { get; set; }
    public Target Target { get; set; } = default!;
}