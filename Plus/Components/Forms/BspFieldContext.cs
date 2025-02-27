using BsBlazor.Helpers;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BsBlazor.Plus;
public class BspFieldContext<TValue>(string? id, EditContext? editContext, Expression<Func<TValue>>? valueExpression, BspFieldGroup? fieldGroup)
{
    public string Id { get; } = BspFieldUtils.ComputeId(id, valueExpression != null ? FieldIdentifier.Create(valueExpression) : null, fieldGroup);
    public string GetValidatableControlClass(string controlClass)
    {
        if (valueExpression is null)
        {
            return controlClass;
        }
        var fieldIdentifier = FieldIdentifier.Create(valueExpression);
        var isValid = editContext?.IsValid(fieldIdentifier) ?? true;
        return CssBuilder.Default(controlClass)
            .AddClass("is-invalid", !isValid)
            .Build();
    }
}
