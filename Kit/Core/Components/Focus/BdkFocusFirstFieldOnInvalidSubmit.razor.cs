using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorDevKit;

public partial class BdkFocusFirstFieldOnInvalidSubmit : ComponentBase, IAsyncDisposable
{
    private ElementReference _elementReference;
    private IJSObjectReference? _jsModuleReference;
    private IJSObjectReference? _jsInstanceReference;

    [Inject] public required IJSRuntime JsRuntime { get; set; }
    [CascadingParameter] public required EditContext EditContext { get; set; }
    
    /// <summary>
    /// By default, the ‘invalid’ class is added to the field that is invalid when the form is submitted and validated by EditContext.
    /// If you want to use a different class, you can set this parameter.
    /// </summary>
    [Parameter] public required string InvalidClass { get; set; } = "invalid";

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
                    _elementReference,
                    InvalidClass
                );
            
            EditContext.OnValidationStateChanged += ValidationStateChanged;
        }
    }

    private async void ValidationStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        if(_jsInstanceReference is null) return;
        await _jsInstanceReference.InvokeVoidAsync("validationChangedAsync");
    }

    public async ValueTask DisposeAsync()
    {
        if(_jsInstanceReference is not null)
        {
            await _jsInstanceReference.InvokeVoidAsync("dispose");
            await _jsInstanceReference.DisposeAsync();
        }

        if(_jsModuleReference is not null)
        {
            await _jsModuleReference.DisposeAsync();
        }
        
        EditContext.OnValidationStateChanged -= ValidationStateChanged;
    }
}