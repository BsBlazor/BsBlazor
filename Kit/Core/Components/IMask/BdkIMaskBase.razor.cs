using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
namespace BlazorDevKit;

public abstract partial class BdkIMaskBase : ComponentBase, IAsyncDisposable
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Inject] public required IJSRuntime JS { get; set; }
    private ElementReference _elementReference;
    private IJSObjectReference? _jsModuleReference;
    private IJSObjectReference? _jsInstanceReference;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _jsModuleReference = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorDevKit.Core/Components/IMask/BdkIMaskBase.razor.js");
            _jsInstanceReference = await _jsModuleReference
                .InvokeAsync<IJSObjectReference>(
                    "BdkIMask.create",
                    DotNetObjectReference.Create(this),
                    _elementReference);
        }
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_jsInstanceReference is not null)
            {
                await _jsInstanceReference.DisposeAsync();
            }

            if (_jsModuleReference is not null)
            {
                await _jsModuleReference.DisposeAsync();
            }
        }
        catch (JSDisconnectedException)
        {
            // Ignore, see:
            // https://stackoverflow.com/questions/72488563/blazor-server-side-application-throwing-system-invalidoperationexception-javas
            // https://github.com/dotnet/aspnetcore/issues/49376
            // https://github.com/dotnet/aspnetcore/issues/30344
        }
    }
}
