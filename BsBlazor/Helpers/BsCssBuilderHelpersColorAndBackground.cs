namespace BsBlazor;

public partial class BsCssBuilder
{
    // Color and Background

    /// <summary>
    /// text-bg-primary
    /// </summary>
    public BsCssBuilder TextBackgroundPrimary => AddClass("text-bg-primary");

    /// <summary>
    /// text-bg-secondary
    /// </summary>
    public BsCssBuilder TextBackgroundSecondary => AddClass("text-bg-secondary");

    /// <summary>
    /// text-bg-success
    /// </summary>
    public BsCssBuilder TextBackgroundSuccess => AddClass("text-bg-success");

    /// <summary>
    /// text-bg-danger
    /// </summary>
    public BsCssBuilder TextBackgroundDanger => AddClass("text-bg-danger");

    /// <summary>
    /// text-bg-warning
    /// </summary>
    public BsCssBuilder TextBackgroundWarning => AddClass("text-bg-warning");

    /// <summary>
    /// text-bg-info
    /// </summary>
    public BsCssBuilder TextBackgroundInfo => AddClass("text-bg-info");

    /// <summary>
    /// text-bg-light
    /// </summary>
    public BsCssBuilder TextBackgroundLight => AddClass("text-bg-light");

    /// <summary>
    /// text-bg-dark
    /// </summary>
    public BsCssBuilder TextBackgroundDark => AddClass("text-bg-dark");
}