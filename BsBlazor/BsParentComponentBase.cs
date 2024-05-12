using Microsoft.AspNetCore.Components;

namespace BsBlazor;

public class BsParentComponentBase : BsComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}