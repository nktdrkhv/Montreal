namespace Montreal.Bot.Poc.Models;

public record Command
{
    public Command(string name, params string[] args)
    {
        Name = name;
        Arguments = args;
    }
    public string Name { get; set; } = default!;
    public string[]? Arguments { get; set; }
}