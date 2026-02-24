using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace BlazorDevKit;

public class BdkIMaskPattern : BdkIMaskBase<string>
{
    protected override string IMaskType => "Pattern";
    [Parameter, EditorRequired] public required string Mask { get; set; }
    [JSInvokable] public string GetMask() => Mask;
    private string? _previousMask = null;
    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        if (JsInstanceReference != null && _previousMask != null && Mask != _previousMask)
        {
            await JsInstanceReference.InvokeVoidAsync("refreshPatternMask");
        }
        _previousMask = Mask;
    }
}
