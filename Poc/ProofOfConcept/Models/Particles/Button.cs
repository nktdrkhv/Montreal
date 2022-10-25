using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public class Button
{
    public int Id { get; set; }
    public ButtonType Type { get; set; }
    public Fragment Source { get; set; } = default!;

    public Target? Target { get; set; }
    public string? Link { get; set; }
    public string? UniqueId { get; set; }

    private string? _label;
    public string? Label
    {
        get
        {
            if (Type is ButtonType.InlineLink or ButtonType.InlineRecommend)
                return _label;
            else
            {
                var contentLabel = this?.Target?.Pointer?.Type switch
                {
                    ContentType.Step => this.Target.Pointer?.Step?.Label,
                    ContentType.Stage => this.Target.Pointer?.Stage?.Label,
                    ContentType.Route => this.Target.Pointer?.Route?.Label,
                    _ => null,
                };
                return _label ?? contentLabel ?? "Кнопка";
            }
        }
        set
        {
            _label = value;
        }
    }

    public int Number { get; set; }
    public int Line { get; set; }
}