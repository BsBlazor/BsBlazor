using FluentValidation.Internal;
using FluentValidation.Validators;
using FluentValidation;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorDevKit;
public static class FluentValidationExtensions
{
    public static IPropertyValidator[] FindRulesFor<TValue>(this IValidator? validator, Expression<Func<TValue>>? expression)
    {
        if (validator is null) { return []; }
        if (expression is null) { return []; }
        // Create member chain from expression
        var propertyChain = PropertyChain.FromExpression(expression);
        var propertyName = propertyChain.ToString();
        var parts = propertyName.Split('.');
        var validators = new[] { validator };
        for (int i = 1; i < parts.Length; i++)
        {
            var part = parts[i];
            var propertyValidators = validators
                .Select(v => v.CreateDescriptor().GetRulesForMember(part))
                .SelectMany(validationRule => validationRule.SelectMany(vr => vr.Components))
                .Select(ruleComponent => ruleComponent.Validator)
                .ToArray();
            // If it's the last part, return the rules
            if (i == parts.Length - 1)
            {
                return propertyValidators;
            }
            else
            {
                var childValidators = new List<IValidator>();
                foreach (var propertyValidator in propertyValidators
                    .Where(pv => pv.Name == nameof(ChildValidatorAdaptor<object, object>)))
                {
                    var validatorField = propertyValidator.GetType().GetField("_validator", BindingFlags.NonPublic | BindingFlags.Instance);
                    var childValidator = validatorField!.GetValue(propertyValidator) as IValidator;
                    childValidators.Add(childValidator!);
                }
                validators = [.. childValidators];
            }
        }
        return [];
    }
}
