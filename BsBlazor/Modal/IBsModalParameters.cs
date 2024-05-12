using Microsoft.AspNetCore.Components;

namespace BsBlazor;
internal interface IBsModalParameters
{
    string? Id { get; set; }
    bool Fade { get; set; }
    bool Keyboard { get; set; }
    BsModalBackdrop Backdrop { get; set; }
    bool ShowWhenRendered { get; set; }

    EventCallback OnHide { get; set; }
    EventCallback OnHidePrevented { get; set; }
    EventCallback OnHidden { get; set; }
    EventCallback OnShow { get; set; }
    EventCallback OnShown { get; set; }
}
