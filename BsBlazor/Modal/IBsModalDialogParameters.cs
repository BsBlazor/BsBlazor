namespace BsBlazor;

internal interface IBsModalDialogParameters
{
    bool Scrollable { get; set; }
    bool Centered { get; set; }
    BsModalSize Size { get; set; }
    BsModalFullscreen Fullscreen { get; set; }
}
