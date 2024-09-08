namespace BsBlazor;
public partial class BsCssBuilder
{
    /// <summary>
    /// card
    /// </summary>
    public BsCssBuilder Card => AddClass("card");
    /// <summary>
    /// card-body
    /// </summary>
    public BsCssBuilder CardBody => AddClass("card-body");
    /// <summary>
    /// card-title
    /// </summary>
    public BsCssBuilder CardTitle => AddClass("card-title");
    /// <summary>
    /// card-img-top
    /// </summary>
    public BsCssBuilder CardImageTop => AddClass("card-img-top");

    /// <summary>
    /// card-img-bottom
    /// </summary>
    public BsCssBuilder CardImageBottom => AddClass("card-img-bottom");
}
