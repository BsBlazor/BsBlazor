using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDevKit;

public partial class BdkFocusFirstFieldOnInvalidSubmit : ComponentBase, IAsyncDisposable
{
    private ElementReference _elementReference;
    private IJSObjectReference? _jsModuleReference;
    private IJSObjectReference? _jsInstanceReference;
    private readonly string _id = Guid.NewGuid().ToString("N");

    [Inject] public required IJSRuntime JsRuntime { get; set; }
    
    /// <summary>
    /// By default, the ‘.invalid, .is-invalid’ selector is added to the field that is invalid when the form is submitted and validated by EditContext.
    /// If you want to use a different class, you can set this parameter.
    /// </summary>
    [Parameter] public required string InvalidSelector { get; set; } = ".invalid, .is-invalid";

    /// <summary>
    /// Force the focus to the first invalid field if the element is not focusable.
    /// </summary>
    [Parameter] public bool Force { get; set; } = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
        {
            _jsModuleReference = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorDevKit.Core/Components/Focus/BdkFocusFirstFieldOnInvalidSubmit.razor.js");
            _jsInstanceReference = await _jsModuleReference
                .InvokeAsync<IJSObjectReference>(
                    "BdkFocusFirstFieldOnInvalidSubmit.create",
                    _id,
                    DotNetObjectReference.Create(this),
                    _elementReference,
                    InvalidSelector
                );
            
        }
    }

    [JSInvokable]
    public async Task NotifySubmitAsync()
    {
        if(_jsInstanceReference is null) return;
        await _jsInstanceReference.InvokeVoidAsync("validationChangedAsync", Force);
    }
    
    public async ValueTask DisposeAsync()
    {
        try
        {
            if (_jsInstanceReference is not null)
            {
                await _jsInstanceReference.InvokeVoidAsync("dispose", _id);
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