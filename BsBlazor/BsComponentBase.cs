using Microsoft.AspNetCore.Components;

namespace BsBlazor;

public class BsComponentBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = [];

    [Parameter]
    public string? Class { get; set; }
}
