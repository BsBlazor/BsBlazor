namespace BsBlazor;

public partial class BsCssBuilder
{
    // Color and Background
    public BsCssBuilder TextBackgroundPrimary => AddClass("text-bg-primary");
    public BsCssBuilder TextBackgroundSecondary => AddClass("text-bg-secondary");
    public BsCssBuilder TextBackgroundSuccess => AddClass("text-bg-success");
    public BsCssBuilder TextBackgroundDanger => AddClass("text-bg-danger");
    public BsCssBuilder TextBackgroundWarning => AddClass("text-bg-warning");
    public BsCssBuilder TextBackgroundInfo => AddClass("text-bg-info");
    public BsCssBuilder TextBackgroundLight => AddClass("text-bg-light");
    public BsCssBuilder TextBackgroundDark => AddClass("text-bg-dark");
}