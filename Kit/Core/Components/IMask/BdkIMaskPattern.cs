using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace BlazorDevKit;

public class BdkIMaskPattern : BdkIMaskBase<string>
{
    protected override string IMaskType => "Pattern";
    [Parameter, EditorRequired] public required string Mask { get; set; }
    [JSInvokable] public string GetMask() => Mask;
}