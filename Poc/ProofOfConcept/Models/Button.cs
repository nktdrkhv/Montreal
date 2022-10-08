namespace Montreal.Bot.Poc.Models;

public record Button
{
    public int Id { get; set; }
    public ButtonType Type { get; set; }

    public string Label { get; set; } = default!;
    public Target Target { get; set; } = default!;
    public int Line { get; set; } = default;
}