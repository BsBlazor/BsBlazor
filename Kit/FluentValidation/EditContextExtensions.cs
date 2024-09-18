﻿using FluentValidation;
using FluentValidation.Validators;
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
        if (editContext.Properties.TryGetValue(BdkFluentValidator<object>.EditContextKey, out var validator))
        {
            return (IValidator)validator;
        }
        return null;
    }
}