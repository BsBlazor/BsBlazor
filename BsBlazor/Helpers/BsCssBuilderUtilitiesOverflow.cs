namespace BsBlazor;
public partial class BsCssBuilder
{
    // Overflow
    public BsCssBuilder OverflowAuto => AddClass("overflow-auto");
    public BsCssBuilder OverflowHidden => AddClass("overflow-hidden");
    public BsCssBuilder OverflowVisible => AddClass("overflow-visible");
    public BsCssBuilder OverflowScroll => AddClass("overflow-scroll");

    public BsCssBuilder OverflowXAuto => AddClass("overflow-x-auto");
    public BsCssBuilder OverflowXHidden => AddClass("overflow-x-hidden");
    public BsCssBuilder OverflowXVisible => AddClass("overflow-x-visible");
    public BsCssBuilder OverflowXScroll => AddClass("overflow-x-scroll");

    public BsCssBuilder OverflowYAuto => AddClass("overflow-y-auto");
    public BsCssBuilder OverflowYHidden => AddClass("overflow-y-hidden");
    public BsCssBuilder OverflowYVisible => AddClass("overflow-y-visible");
    public BsCssBuilder OverflowYScroll => AddClass("overflow-y-scroll");
}
