using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop.Implementation;
namespace Microsoft.JSInterop;
public static class JsRuntimeExtensions
{
    public static async Task<IJSObjectReference> GetJsReference(this IJSRuntime jsRuntime, ElementReference element)
    {
        return await jsRuntime.InvokeAsync<JSObjectReference>("Bdk.getJsReference", element);
    }
}
