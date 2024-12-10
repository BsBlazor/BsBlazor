using FluentValidation.Internal;
using FluentValidation.Validators;
using System.Linq.Expressions;
using System.Reflection;
namespace FluentValidation;
/* exploring tracking required fields using a base class */
public abstract class TrackRequiredValidator<T> : AbstractValidator<T>
{

    protected override void OnRuleAdded(IValidationRule<T> rule)
    {
        rule.ApplySharedCondition(context =>
        {
            if (rule.Components.FirstOrDefault(c => c.Validator is INotEmptyValidator or INotNullValidator) is IRuleComponent ruleComponent)
            {
                // reflection....
                var conditionField = ruleComponent.GetType().GetField("_condition", BindingFlags.NonPublic | BindingFlags.Instance);
                var condition = conditionField?.GetValue(ruleComponent) as Func<ValidationContext<T>, bool>;
                if (condition == null || condition(context))
                {
                    //var isValid = ruleComponent.Validator.GetType().GetMethod("IsValid");
                    var methods = GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
                    var verifyRequiredMethod = typeof(TrackRequiredValidator<T>).GetMethod(nameof(MarkRequired), BindingFlags.NonPublic | BindingFlags.Static)
                                                        .MakeGenericMethod(rule.TypeToValidate);
                    verifyRequiredMethod.Invoke(null, [rule, ruleComponent.Validator, context]);
                    //RequiredTracker.VerifyRequired()
                    //rule.TypeToValidate

                    Console.WriteLine("too much...");
                }
                // var condition = conditionProperty?.GetValue(ruleComponent) as IPropertyValidator;

            }
            return true;
        });


        //rule.ApplySharedCondition(context =>
        //{
        //    var r = rule;
        //    var requiredComponent = rule.Components.FirstOrDefault(c => c.Validator is INotEmptyValidator or INotNullValidator);
        //    if (requiredComponent != null)
        //    {
        //        // Very reflectish....
        //        var conditionProperty = requiredComponent.GetType().GetField("_condition", BindingFlags.NonPublic | BindingFlags.Instance);
        //        //var when = conditionProperty?.GetValue(requiredComponent)?;
        //        var isValidMethod = requiredComponent.Validator.GetType().GetMethod("IsValid");

        //        //var when = requiredComponent.HasCondition
        //    }
        //    return true;
        //});

        base.OnRuleAdded(rule);
    }

    private static void Xurumelas() { }

    private static void MarkRequired<TProperty>(IValidationRule<T> rule, IPropertyValidator<T, TProperty> validator, ValidationContext<T> context)
    {
        if (context.RootContextData.TryGetValue("Requireds", out object? requiredsInstance) && !validator.IsValid(context, default!))
        {

            var memberExpression = rule.Expression.Body as MemberExpression ?? (rule.Expression.Body as UnaryExpression)?.Operand as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Expression must be a member expression");
            }
            var targetModel = Expression.Lambda(memberExpression.Expression!, rule.Expression.Parameters).Compile().DynamicInvoke(context.InstanceToValidate);
            var requireds = (HashSet<(object model, string fieldName)>)requiredsInstance;
            requireds.Add((targetModel!, memberExpression.Member.Name));
        }
    }
}
