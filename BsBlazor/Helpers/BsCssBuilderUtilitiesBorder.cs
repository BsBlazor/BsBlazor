namespace BsBlazor;

public partial class BsCssBuilder
{
    // Border
    public BsCssBuilder Border => AddClass("border");
    public BsCssBuilder BorderTop => AddClass("border-top");
    public BsCssBuilder BorderEnd => AddClass("border-end");
    public BsCssBuilder BorderBottom => AddClass("border-bottom");
    public BsCssBuilder BorderStart => AddClass("border-start");
    
    // Border Color
    public BsCssBuilder BorderPrimary => AddClass("border-primary");
    public BsCssBuilder BorderPrimarySubtle => AddClass("border-primary-subtle");
    public BsCssBuilder BorderSecondary => AddClass("border-secondary");
    public BsCssBuilder BorderSecondarySubtle => AddClass("border-secondary-subtle");
    public BsCssBuilder BorderSuccess => AddClass("border-success");
    public BsCssBuilder BorderSuccessSubtle => AddClass("border-success-subtle");
    public BsCssBuilder BorderDanger => AddClass("border-danger");
    public BsCssBuilder BorderDangerSubtle => AddClass("border-danger-subtle");
    public BsCssBuilder BorderWarning => AddClass("border-warning");
    public BsCssBuilder BorderWarningSubtle => AddClass("border-warning-subtle");
    public BsCssBuilder BorderInfo => AddClass("border-info");
    public BsCssBuilder BorderInfoSubtle => AddClass("border-info-subtle");
    public BsCssBuilder BorderLight => AddClass("border-light");
    public BsCssBuilder BorderLightSubtle => AddClass("border-light-subtle");
    public BsCssBuilder BorderDark => AddClass("border-dark");
    public BsCssBuilder BorderDarkSubtle => AddClass("border-dark-subtle");
    public BsCssBuilder BorderBlack => AddClass("border-black");
    public BsCssBuilder BorderWhite => AddClass("border-white");
    
}