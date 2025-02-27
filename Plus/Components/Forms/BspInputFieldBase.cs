using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using BsBlazor.Helpers;

namespace BsBlazor.Plus;

public abstract class BspInputFieldBase<TValue> : BsComponentBase
{
#pragma warning disable S2743 // Static fields should not be used in generic types
    private static int _instanceCount;
#pragma warning restore S2743 // Static fields should not be used in generic types
    
    [CascadingParameter] protected EditContext? EditContext { get; set; }
    [Parameter] public string? Id { get; set; }
    [Parameter] public BsFormControlSize Size { get; set; } = BsFormControlSize.Default;
    [Parameter] public string Label { get; set; } = string.Empty;
    [Parameter] public bool ShowLabel { get; set; } = true;
    [Parameter] public string Placeholder { get; set; } = string.Empty;
    // Navigating through enhanced navigation to a static page with a field is not supported.
    [Parameter] public bool AutoFocus { get; set; }
    [Parameter] public bool Immediate { get; set; }
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool ReadOnly { get; set; }
    [Parameter] public bool? Required { get; set; }


    /// <summary>
    /// Gets or sets the value of the input. This should be used with two-way binding.
    /// </summary>
    /// <example>
    /// @bind-Value="model.PropertyName"
    /// </example>
    [Parameter, EditorRequired] public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets a callback that updates the bound value.
    /// </summary>
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }

    public virtual ValueTask FocusAsync() => ValueTask.CompletedTask;

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && AutoFocus)
        {
            await FocusAsync();
        }
        await base.OnAfterRenderAsync(firstRender);
    }
}
