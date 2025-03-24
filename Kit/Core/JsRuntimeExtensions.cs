using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop.Implementation;
namespace Microsoft.JSInterop;
public static class JsRuntimeExtensions
{
    public static async Task<IJSObjectReference> GetJsReferenceAsync(this IJSRuntime jsRuntime, ElementReference element)
    {
        return await jsRuntime.InvokeAsync<IJSObjectReference>("Bdk.getJsReference", element);
    }
}
