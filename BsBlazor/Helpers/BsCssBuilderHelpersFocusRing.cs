namespace BsBlazor;

public partial class BsCssBuilder
{
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
}