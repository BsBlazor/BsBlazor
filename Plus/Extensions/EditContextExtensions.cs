using BlazorDevKit;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BsBlazor.Plus;
internal static class EditContextExtensions
{
    public static bool IsRequired<TValue>(this EditContext editContext, Expression<Func<TValue>>? valueExpression)
    {
        return editContext.IsFluentValidationRequired(valueExpression) 
               || IsRequiredFromDataAnnotations(valueExpression);
    }

    private static bool IsRequiredFromDataAnnotations<TValue>(Expression<Func<TValue>>? valueExpression)
    {
        if (valueExpression is null) { return false; }
        var isRequiredFromDataAnnotations = false;
        if (valueExpression is { Body: MemberExpression memberExpression })
        {
            var propertyInfo = memberExpression.Member as System.Reflection.PropertyInfo;
            if (propertyInfo != null)
            {
                isRequiredFromDataAnnotations = propertyInfo.CustomAttributes.Any(a => a.AttributeType == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute));
            }
        }
        return isRequiredFromDataAnnotations;
    }
}
