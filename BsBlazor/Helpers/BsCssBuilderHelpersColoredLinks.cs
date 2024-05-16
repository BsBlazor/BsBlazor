namespace BsBlazor;

public partial class BsCssBuilder
{
    // Colored Links
    public BsCssBuilder LinkPrimary => AddClass("link-primary");
    public BsCssBuilder LinkSecondary => AddClass("link-secondary");
    public BsCssBuilder LinkSuccess => AddClass("link-success");
    public BsCssBuilder LinkDanger => AddClass("link-danger");
    public BsCssBuilder LinkWarning => AddClass("link-warning");
    public BsCssBuilder LinkInfo => AddClass("link-info");
    public BsCssBuilder LinkLight => AddClass("link-light");
    public BsCssBuilder LinkDark => AddClass("link-dark");
    public BsCssBuilder LinkBodyEmphasisMuted => AddClass("link-body-emphasis-muted");
}