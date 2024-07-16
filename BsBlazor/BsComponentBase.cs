using Microsoft.AspNetCore.Components;

namespace BsBlazor;

public class BsComponentBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?> AdditionalAttributes { get; set; } = [];

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }
    
    protected void AddAttribute(string key, object value) => AdditionalAttributes[key] = value;
    protected void AddAttributeWhen(bool condition, string key, object value)
    {
        if (condition)
        {
            AddAttribute(key, value);
        }
    }
    //protected bool RemoveAttribute(string key) => AdditionalAttributes.Remove(key);
}
