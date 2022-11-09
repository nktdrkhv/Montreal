using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Models;

public class Button
{
    public int Id { get; set; }
    public ButtonType Type { get; set; }
    public Fragment AttachedTo { get; set; } = default!;

    public Target? Target { get; set; }
    public string? Link { get; set; }
    public string? UniqueId { get; set; }
    //public string? Notification {get;set;}

    //public string ButtonLabel (string text, int line, int number)

    public int Number { get; set; }
    public int Line { get; set; }

    private string? _label;
    public string? Label
    {
        get
        {
            if (Type is ButtonType.InlineLink or ButtonType.InlineNotification)
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
                return _label ?? contentLabel;
            }
        }
        set
        {
            _label = value;
        }
    }
}