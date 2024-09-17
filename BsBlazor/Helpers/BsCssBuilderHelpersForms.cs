namespace BsBlazor;
public partial class BsCssBuilder
{
    /// <summary>
    /// form-control
    /// </summary>
    public BsCssBuilder FormControl => AddClass("form-control");

    /// <summary>
    /// form-floating
    /// </summary>
    public BsCssBuilder FormFloating => AddClass("form-floating");

    /// <summary>
    /// form-label
    /// </summary>
    public BsCssBuilder FormLabel => AddClass("form-label");

    /// <summary>
    /// form-text
    /// </summary>
    public BsCssBuilder FormText => AddClass("form-text");
}