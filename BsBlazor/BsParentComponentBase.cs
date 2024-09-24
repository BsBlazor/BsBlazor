using Microsoft.AspNetCore.Components;

namespace BsBlazor;

public class BsComponentWithContentBase : BsComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}