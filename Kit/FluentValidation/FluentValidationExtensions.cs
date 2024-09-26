using FluentValidation.Internal;
using FluentValidation.Validators;
using FluentValidation;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorDevKit;
public static class FluentValidationExtensions
{

    //public static IPropertyValidator[] FindRulesFor<TValue>(this IValidator? validator, Expression<Func<TValue>>? expression)
    //{
    //    if (validator is null) { return []; }
    //    if (expression is null) { return []; }
    //    //validator.Validate(new ValidationContext)
    //    var allPropertyValidators = FindPropertyValidatorsRecursive(validator, []);
    //    return allPropertyValidators;
    //}

    //private static IPropertyValidator[] FindPropertyValidatorsRecursive(IValidator validator, IPropertyValidator[] current)
    //{
    //    var descriptor = validator.CreateDescriptor();
    //    var groups = descriptor.GetMembersWithValidators();
    //    foreach (var memberValidatorsGroup in groups)
    //    {
    //        var propertyValidators = memberValidatorsGroup.Select(tuple => tuple.Validator);
    //        current = [.. current, .. propertyValidators];
    //    }
    //    return current;
    //    //var childValidators = propertyValidators
    //    //    .SelectMany(pv => pv)
    //    //    .Select(v => v.Validator)
    //    //    .Where(v => v != null)
    //    //    .SelectMany(v => FindPropertyValidatorsRecursive(v!))
    //    //    .ToArray();
    //    //return propertyValidators.Concat(childValidators).ToArray();
    //}

    public static bool IsRequired<TValue>(this IValidator validator, Expression<Func<TValue>> expression)
    {
        var rules = validator.FindRulesFor(expression);
        return Array.Exists(rules, v => v is INotEmptyValidator or INotNullValidator);
    }

    public static IPropertyValidator[] FindRulesFor<TValue>(this IValidator? validator, Expression<Func<TValue>>? expression)
    {
        if (validator is null) { return []; }
        if (expression is null) { return []; }
        var propertyChainName = expression.ToString().Split(").").LastOrDefault("");
        var parts = propertyChainName.Split('.');
        var validators = new[] { validator };
        var from = 0;

        for (int i = from; i < parts.Length; i++)
        {
            var part = parts[i];
            var propertyValidators = validators
                .Select(v => v.CreateDescriptor().GetRulesForMember(part))
                .SelectMany(validationRule => validationRule.SelectMany(vr => vr.Components))
                .Select(ruleComponent => ruleComponent.Validator)
                .ToArray();
            if (propertyValidators.Length == 0) { continue; }
            // If it's the last part, return the rules
            if (i == parts.Length - 1)
            {
                return propertyValidators;
            }
            else
            {
                // Otherwise get the child validators
                var childValidators = new List<IValidator>();
                foreach (var propertyValidator in propertyValidators
                    .Where(pv => pv.Name == nameof(ChildValidatorAdaptor<object, object>)))
                {
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
                    var validatorField = propertyValidator.GetType().GetField("_validator",
                        BindingFlags.NonPublic | BindingFlags.Instance);
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
                    var childValidator = validatorField!.GetValue(propertyValidator) as IValidator;
                    childValidators.Add(childValidator!);
                }
                validators = [.. childValidators];
            }
        }
        return [];
    }
}
