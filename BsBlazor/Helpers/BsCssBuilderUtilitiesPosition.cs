namespace BsBlazor;

public partial class BsCssBuilder
{
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
}