namespace BsBlazor;

public class ToastOptions
{
    public string? Class { get; set; }
    public BsToastColor? Color { get; set; }

    public int? Delay { get; set; }
    public bool? AutoHide { get; set; }
    public bool? Animation { get; set; }

    public bool ShowCloseButtonIcon { get; set; } = true;
}