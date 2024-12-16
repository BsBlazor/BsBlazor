using FluentValidation.Internal;
using FluentValidation.Validators;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentValidation;
public static class ValidatorExtensions
{
    public static bool IsRequired<T, TProperty>(this IValidator validator, T rootInstance, Expression<Func<TProperty>> valueExpression)
    {
        var member = valueExpression.Body as MemberExpression ?? (valueExpression.Body as UnaryExpression)?.Operand as MemberExpression;
        if (member == null)
        {
            throw new ArgumentException("Expression must be a member expression");
        }
        var targetModel = Expression.Lambda(member.Expression!).Compile().DynamicInvoke();
        var fieldName = member.Member.Name;
        return validator.IsRequired(rootInstance, targetModel ?? rootInstance!, fieldName);
    }

    public static bool IsRequired<T>(
        this IValidator validator,
        T rootInstance,
        object targetInstance,
        string fieldName)
    {
        var descriptor = validator.CreateDescriptor();
        return IsInlineRequired(descriptor, rootInstance, targetInstance, fieldName)
            || IsChildAdaptorRequired(descriptor, rootInstance, targetInstance, fieldName);
    }

    private static bool IsChildAdaptorRequired(IValidatorDescriptor descriptor, object rootInstance, object targetInstance, string fieldName)
    {
        var rulesWithChildAdaptors = descriptor.Rules.Where(r => r.Components.Any(c => c.Validator.Name == nameof(ChildValidatorAdaptor<object, object>))).ToArray();
        foreach (var ruleWithChildAdaptor in rulesWithChildAdaptors)
        {
            var childInstance = ruleWithChildAdaptor.Expression == null ? rootInstance : // If Expression is null, it means the rule is for the root object itself. This happens when using "ctor() { Include(new ValidatorForThis()); }"
                                ruleWithChildAdaptor.Expression.Compile().DynamicInvoke(rootInstance);
            if (childInstance is null) { continue; }
            var adaptorComponent = ruleWithChildAdaptor.Components.FirstOrDefault(c => c.Validator.Name == nameof(ChildValidatorAdaptor<object, object>));
            if (adaptorComponent.HasCondition && !CheckCondition(adaptorComponent, rootInstance)) { continue; }
            var adaptor = adaptorComponent.Validator as IChildValidatorAdaptor;
            var innerValidator = adaptor.GetType().GetField("_validator", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(adaptor) as IValidator;
            var innerValidatorProvider = adaptor.GetType().GetField("_validatorProvider", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(adaptor) as Delegate;
            if (ruleWithChildAdaptor.GetType().Name == "CollectionPropertyRule`2")
            {
                var items = childInstance as IEnumerable;
                foreach (var item in items)
                {
                    var validator = innerValidator ?? innerValidatorProvider.DynamicInvoke(
                        Activator.CreateInstance(typeof(ValidationContext<>).MakeGenericType(rootInstance.GetType()), rootInstance),
                        item) as IValidator;
                    var childValidatorDescriptor = validator.CreateDescriptor();
                    var isRequired = IsInlineRequired(childValidatorDescriptor, item, targetInstance, fieldName)
                            || IsChildAdaptorRequired(childValidatorDescriptor, item, targetInstance, fieldName);
                    if (isRequired) { return true; }
                }
            }
            else // RuleFor(x => x.Child).Etc
            {
                var validator = innerValidator ?? innerValidatorProvider.DynamicInvoke(
                    Activator.CreateInstance(typeof(ValidationContext<>).MakeGenericType(rootInstance.GetType()), rootInstance),
                    childInstance) as IValidator;
                var childValidatorDescriptor = validator.CreateDescriptor();
                var isRequired = IsInlineRequired(childValidatorDescriptor, childInstance, targetInstance, fieldName) || IsChildAdaptorRequired(childValidatorDescriptor, childInstance, targetInstance, fieldName);
                if (isRequired) { return true; }
            }
        }
        return false;
    }

    private static bool IsInlineRequired(IValidatorDescriptor descriptor, object rootInstance, object targetInstance, string fieldName)
    {
        var ruleWithRequiredValidator = descriptor.Rules
                                           .Where(r => r.PropertyName != null) // FluentValidation must adjust the nullability of PropertyName
                                           .Where(r => r.PropertyName.Split('.').Last() == fieldName)
                                           .Where(r => r.Components.Any(c => c.Validator is INotEmptyValidator or INotNullValidator))
                                           .FirstOrDefault(r =>
                                           {
                                               var memberExpression = r.Expression.Body as MemberExpression ?? (r.Expression.Body as UnaryExpression)?.Operand as MemberExpression;
                                               var compiledTarget = Expression.Lambda(memberExpression.Expression!, r.Expression.Parameters).Compile().DynamicInvoke(rootInstance);
                                               return compiledTarget == targetInstance;
                                           });
        if (ruleWithRequiredValidator == null) { return false; }
        var requiredComponent = ruleWithRequiredValidator.Components.FirstOrDefault(c => c.Validator is INotEmptyValidator or INotNullValidator);
        if (requiredComponent.HasCondition)
        {
            return CheckCondition(requiredComponent, rootInstance);
        }

        return true;
    }

    public static bool CheckCondition(IRuleComponent component, object instance)
    {
        var conditionField = component.GetType().GetField("_condition", BindingFlags.NonPublic | BindingFlags.Instance);
        var condition = conditionField?.GetValue(component) as Delegate;
        var context = Activator.CreateInstance(typeof(ValidationContext<>).MakeGenericType(instance.GetType()), instance);
        return (bool)condition.DynamicInvoke(context);
    }
}