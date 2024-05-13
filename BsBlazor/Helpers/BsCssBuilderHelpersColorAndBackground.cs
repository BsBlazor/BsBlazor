namespace BsBlazor;

public partial class BsCssBuilder
{
    // Color and Background
    public BsCssBuilder TextBgPrimary => AddClass("text-bg-primary");
    public BsCssBuilder TextBgSecondary => AddClass("text-bg-secondary");
    public BsCssBuilder TextBgSuccess => AddClass("text-bg-success");
    public BsCssBuilder TextBgDanger => AddClass("text-bg-danger");
    public BsCssBuilder TextBgWarning => AddClass("text-bg-warning");
    public BsCssBuilder TextBgInfo => AddClass("text-bg-info");
    public BsCssBuilder TextBgLight => AddClass("text-bg-light");
    public BsCssBuilder TextBgDark => AddClass("text-bg-dark");
}