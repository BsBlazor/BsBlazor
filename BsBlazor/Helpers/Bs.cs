using System.Text;

namespace BsBlazor;

public static class Bs
{
    public static BsCssBuilder Css => new(string.Empty);
    public static BsCssBuilder Default(string value) => new(value);
}

public class BsCssBuilder
{
    private readonly StringBuilder? _buffer;
    private readonly Action<string>? _addCssClassAction;

    public BsCssBuilder(string value)
    {
        _buffer = new StringBuilder();
        _buffer.Append(value);
    }

    internal BsCssBuilder(Action<string?> addCssClassAction) => _addCssClassAction = addCssClassAction;

    private BsCssBuilder AddClass(string value)
    {
        
        if (_buffer is not null)
        {
            _buffer.Append(" " + value);
        }
        else
        {
            _addCssClassAction?.Invoke(value);
        }
        
        return this;
    }
    
    #region Helpers

    // Clearfix
    public BsCssBuilder Clearfix => AddClass("clearfix");
    
    // Color and Background
    public BsCssBuilder TextBgPrimary => AddClass("text-bg-primary");
    public BsCssBuilder TextBgSecondary => AddClass("text-bg-secondary");
    public BsCssBuilder TextBgSuccess => AddClass("text-bg-success");
    public BsCssBuilder TextBgDanger => AddClass("text-bg-danger");
    public BsCssBuilder TextBgWarning => AddClass("text-bg-warning");
    public BsCssBuilder TextBgInfo => AddClass("text-bg-info");
    public BsCssBuilder TextBgLight => AddClass("text-bg-light");
    public BsCssBuilder TextBgDark => AddClass("text-bg-dark");
    
    // Colored Links
    public BsCssBuilder LinkPrimary => AddClass("link-primary");
    public BsCssBuilder LinkSecondary => AddClass("link-secondary");
    public BsCssBuilder LinkSuccess => AddClass("link-success");
    public BsCssBuilder LinkDanger => AddClass("link-danger");
    public BsCssBuilder LinkWarning => AddClass("link-warning");
    public BsCssBuilder LinkInfo => AddClass("link-info");
    public BsCssBuilder LinkLight => AddClass("link-light");
    public BsCssBuilder LinkDark => AddClass("link-dark");
    public BsCssBuilder LinkBodyEmphasis => AddClass("link-body-emphasis-muted");
    
    // Focus Ring
    public BsCssBuilder FocusRing => AddClass("focus-ring");
    
    public BsCssBuilder FocusRingPrimary => AddClass("focus-ring-primary");
    public BsCssBuilder FocusRingSecondary => AddClass("focus-ring-secondary");
    public BsCssBuilder FocusRingSuccess => AddClass("focus-ring-success");
    public BsCssBuilder FocusRingDanger => AddClass("focus-ring-danger");
    public BsCssBuilder FocusRingWarning => AddClass("focus-ring-warning");
    public BsCssBuilder FocusRingInfo => AddClass("focus-ring-info");
    public BsCssBuilder FocusRingLight => AddClass("focus-ring-light");
    public BsCssBuilder FocusRingDark => AddClass("focus-ring-dark");

    #endregion

    #region Utilities

    // Position
    public BsCssBuilder PositionAbsolute => AddClass("position-absolute");
    public BsCssBuilder PositionFixed => AddClass("position-fixed");
    public BsCssBuilder PositionRelative => AddClass("position-relative");
    public BsCssBuilder PositionStatic => AddClass("position-static");
    public BsCssBuilder PositionSticky => AddClass("position-sticky");
    
    public BsCssBuilder Top0 => AddClass("top-0");
    public BsCssBuilder Top50 => AddClass("top-50");
    public BsCssBuilder Top100 => AddClass("top-100");
    
    public BsCssBuilder Bottom0 => AddClass("bottom-0");
    public BsCssBuilder Bottom50 => AddClass("bottom-50");
    public BsCssBuilder Bottom100 => AddClass("bottom-100");
    
    public BsCssBuilder Start0 => AddClass("start-0");
    public BsCssBuilder Start50 => AddClass("start-50");
    public BsCssBuilder Start100 => AddClass("start-100");
    
    public BsCssBuilder End0 => AddClass("end-0");
    public BsCssBuilder End50 => AddClass("end-50");
    public BsCssBuilder End100 => AddClass("end-100");
    
    public BsCssBuilder TranslateMiddleX => AddClass("translate-middle-x");
    public BsCssBuilder TranslateMiddleY => AddClass("translate-middle-y");
    public BsCssBuilder TranslateMiddle => AddClass("translate-middle");
    
    
    public BsCssBuilder TopLeft => Top0.Start0;
    public BsCssBuilder TopCenter => Top0.Start50.TranslateMiddleX;
    public BsCssBuilder TopRight => Top0.End0;
    
    public BsCssBuilder MiddleLeft => Top50.Start0.TranslateMiddleY;
    public BsCssBuilder MiddleCenter => Top50.Start50.TranslateMiddle;
    public BsCssBuilder MiddleRight => Top50.End0.TranslateMiddleY;
    
    public BsCssBuilder BottomLeft => Bottom0.Start0;
    public BsCssBuilder BottomCenter => Bottom0.Start50.TranslateMiddleX;
    public BsCssBuilder BottomRight => Bottom0.End0;

    #endregion
    
    private string Build() => _buffer?.ToString().Trim() ?? string.Empty;
    public static implicit operator string(BsCssBuilder builder) => builder.Build();
    public override string ToString() => Build();
}