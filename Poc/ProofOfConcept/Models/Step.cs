using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public record Step : ContentBase
{
    public Fragment[] Fragments { get; set; } = default!;
}