using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BlazorDevKit;
public static class EditContextFluentValidationExtensions
{
    public static bool IsFluentValidationRequired<TValue>(this EditContext editContext, Expression<Func<TValue>>? valueExpression)
    {
        var validator = editContext.GetValidator();
        var isRequiredFromFluentValidation =
            valueExpression != null
            &&
            validator != null
            &&
            Array.Exists(validator.FindRulesFor(valueExpression), v => v is INotEmptyValidator or INotNullValidator);
        return isRequiredFromFluentValidation;
    }

    private static IValidator? GetValidator(this EditContext? editContext)
    {
        if (editContext is null) { return null; }
        if (editContext.Properties.TryGetValue("AppValidator", out var validator))
        {
            return (IValidator)validator;
        }
        return null;
    }
}
