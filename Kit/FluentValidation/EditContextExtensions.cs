using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BlazorDevKit;
public static class EditContextFluentValidationExtensions
{
    /// <summary>
    /// When using <BdkFluentValidator>, checks if the field is required by FluentValidation.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="editContext"></param>
    /// <param name="valueExpression"></param>
    /// <returns></returns>
    public static bool IsFluentValidationRequired<TValue>(this EditContext editContext, Expression<Func<TValue>>? valueExpression)
    {
        if(valueExpression == null) { return false; }
        var validatorContext = editContext.GetBdkFluentValidatorContext();
        if(validatorContext == null) { return false; }
        var fieldIdentifier = FieldIdentifier.Create(valueExpression);
        return valueExpression != null && validatorContext.IsRequired(fieldIdentifier);
    }

    private static BdkFluentValidatorContext? GetBdkFluentValidatorContext(this EditContext? editContext)
    {
        if (editContext is null) { return null; }
        if (editContext.Properties.TryGetValue(BdkFluentValidator<object>.EditContextKey, out var validator))
        {
            return (BdkFluentValidatorContext)validator;
        }
        return null;
    }
}
