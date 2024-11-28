using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace BlazorDevKit;

public abstract partial class BdkIMaskBase<T> : ComponentBase, IAsyncDisposable
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public T? Value { get; set; }
    [Parameter] public EventCallback<T?> ValueChanged { get; set; }
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
    public void AcceptValue(string? value, string? unmaskedValue, T? typedValue)
    {
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
                thisAsString.ValueChanged.InvokeAsync(value);
                break;
            case BdkIMaskBindTarget.UnmaskedValue:
                if (thisAsString is null)
                {
                    throw new InvalidOperationException("Cannot bind to UnmaskedValue when T is not string");
                }
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                thisAsString.Value = unmaskedValue;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
                thisAsString.ValueChanged.InvokeAsync(unmaskedValue);
                break;
            case BdkIMaskBindTarget.TypedValue:
                Value = typedValue;
                ValueChanged.InvokeAsync(typedValue);
                break;
        }
    }

    
}
public class BdkIMaskUpdateData<T>
{
    public string? Value { get; set; }
    public string? UnmaskedValue { get; set; }
    public T? TypedValue { get; set; }
}