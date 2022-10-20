using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public class Step : ContentBase
{
    public List<Fragment> Fragments { get; set; } = default!;
}