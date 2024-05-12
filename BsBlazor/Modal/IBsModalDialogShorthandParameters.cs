using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal interface IBsModalDialogShorthandParameters
{
    string Title { get; set; }
    bool ShowDismissButton { get; set; }
    bool ShowPrimaryButton { get; set; }
    string DismissButtonText { get; set; }
    string PrimaryButtonText { get; set; }
    EventCallback OnPrimaryButtonClick { get; set; }
    public RenderFragment? CustomFooter { get; set; }
}