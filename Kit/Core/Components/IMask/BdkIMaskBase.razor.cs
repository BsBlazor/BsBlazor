using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Linq.Expressions;
namespace BlazorDevKit;

public abstract partial class BdkIMaskBase<T> : ComponentBase, IAsyncDisposable
{
    private Context _context = null!;
    [CascadingParameter] private EditContext? EditContext { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public RenderFragment<Context>? MaskContext { get; set; }

    [Parameter] public T? Value { get; set; }
    [Parameter] public EventCallback<T?> ValueChanged { get; set; }
    [Parameter] public Expression<Func<T>>? ValueExpression { get; set; }
    [Parameter] public BdkIMaskBindTarget BindTarget { get; set; } = BdkIMaskBindTarget.None;
    private string BindTargetAsString => BindTarget switch
    {
        BdkIMaskBindTarget.Value => "value",
        BdkIMaskBindTarget.UnmaskedValue => "unmaskedValue",
        BdkIMaskBindTarget.TypedValue => "typedValue",
        _ => ""
    };

    [Inject] public required IJSRuntime JS { get; set; }
    private ElementReference _elementReference;
    private IJSObjectReference? _jsModuleReference;
    private IJSObjectReference? _jsInstanceReference;
    protected override void OnInitialized()
    {
        _context = new Context(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _jsModuleReference = await JS.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorDevKit.Core/Components/IMask/BdkIMaskBase.razor.js");
            _jsInstanceReference = await _jsModuleReference.InvokeAsync<IJSObjectReference>("BdkIMask.create", DotNetObjectReference.Create(this), _elementReference);
            if (BindTarget != BdkIMaskBindTarget.None)
            {
                await _jsInstanceReference.InvokeVoidAsync("setValue", Value, BindTargetAsString);
            }
            StateHasChanged();
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_jsInstanceReference is not null && BindTarget != BdkIMaskBindTarget.None)
        {
            await _jsInstanceReference.InvokeVoidAsync("setValue", Value, BindTargetAsString);
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
    protected abstract string IMaskType { get; }
    [JSInvokable] public string GetIMaskType() => IMaskType;
    [JSInvokable]
    public async Task AcceptValue(string? value, string? unmaskedValue, T? typedValue)
    {
        _context.MaskedValue = value;      
        var thisAsString = this as BdkIMaskBase<string>;
        switch(BindTarget)
        {
            case BdkIMaskBindTarget.Value:
                if(thisAsString is null)
                {
                    throw new InvalidOperationException("Cannot bind to Value when T is not string");
                }
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                thisAsString.Value = value;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                await  thisAsString.ValueChanged.InvokeAsync(value);
                break;
            case BdkIMaskBindTarget.UnmaskedValue:
                if (thisAsString is null)
                {
                    throw new InvalidOperationException("Cannot bind to UnmaskedValue when T is not string");
                }
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                thisAsString.Value = unmaskedValue;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                await thisAsString.ValueChanged.InvokeAsync(unmaskedValue);
                break;
            case BdkIMaskBindTarget.TypedValue:
                Value = typedValue;
                await ValueChanged.InvokeAsync(typedValue);
                break;
        }
        if(EditContext != null && ValueExpression != null)
        {
            var fieldIdentifier = FieldIdentifier.Create(ValueExpression);
            EditContext.NotifyFieldChanged(fieldIdentifier);
            EditContext.NotifyValidationStateChanged();
        }
    }

    private async Task<string> GetUnmaskedValueAsync()
    {
        if (_jsInstanceReference is not null)
        {
            return await _jsInstanceReference.InvokeAsync<string>("getUnmaskedValue");
        }
        return "";
    }

    public class Context(BdkIMaskBase<T> iMaskComponent)
    {
        public string? MaskedValue { get; internal set; }
        public async Task<string> GetUnmaskedValueAsync() => await iMaskComponent.GetUnmaskedValueAsync();
    }

}
