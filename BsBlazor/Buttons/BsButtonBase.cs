using BsBlazor.Extensions;
using BsBlazor.Helpers;
using Microsoft.AspNetCore.Components;
namespace BsBlazor;
public abstract class BsButtonBase : BsComponentBase
{
    [Parameter] public BsButtonSize Size { get; set; }
    // Instead of using BsThemeColor direclty, we use BsButtonVariant
    // because there are excludent combinations of theme colors and variants.
    // For example, the button has a btn-link variant that don't have a theme color.
    [Parameter] public BsButtonVariant Variant { get; set; }
    
    internal virtual CssBuilder CssBuilder => CssBuilder
        .Default("btn")
        .AddClass("btn-lg", Size is BsButtonSize.Large)
        .AddClass("btn-sm", Size is BsButtonSize.Small)
        .AddClass($"btn-{Variant.ToKebabCase()}", Variant is not BsButtonVariant.None)
        .AddClass(Class);

    protected override void OnParametersSet()
    {
        AddAttributeWhen(Style is not null, "style", Style!);
    }
}