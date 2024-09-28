using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDevKit;
public partial class BdkFocusOnRender : ComponentBase, IAsyncDisposable
{
    private ElementReference _elementReference;
    private IJSObjectReference? _jsModuleReference;
    [Inject] public required IJSRuntime JsRuntime { get; set; }

    [Parameter, EditorRequired] public string Selector { get; set; } = "*";

    /// <summary>
    /// Delay in milliseconds before focusing the element
    /// </summary>
    [Parameter] public int Delay { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _jsModuleReference = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorDevKit.Core/Components/Focus/BdkFocusOnRender.razor.js");
            await _jsModuleReference.InvokeVoidAsync(
                    $"{nameof(BdkFocusOnRender)}.focusAsync",
                    _elementReference,
                    Selector,
                    Delay
                );

        }
    }


    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_jsModuleReference is not null)
            {
                await _jsModuleReference.DisposeAsync();
            }
            GC.SuppressFinalize(this);
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