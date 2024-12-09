using System.Linq.Expressions;

namespace FluentValidation;
public static class ValidatorExtensions
{
    public static bool IsRequired<T>(
        this IValidator validator, 
        T rootInstance,
        object targetInstance, 
        string fieldName)
    {
        var validationContext = new ValidationContext<T>(rootInstance);
        var requireds = new HashSet<(object model, string fieldName)>();
        validationContext.RootContextData["Requireds"] = requireds;
        validator.Validate(validationContext);
        return requireds.Contains((targetInstance, fieldName));
    }

    public static bool IsRequired<T, TProperty>(this IValidator validator, T rootInstance, Expression<Func<TProperty>> valueExpression)
    {
        var member = valueExpression.Body as MemberExpression ?? (valueExpression.Body as UnaryExpression)?.Operand as MemberExpression;
        if (member == null)
        {
            throw new ArgumentException("Expression must be a member expression");
        }
        var constantExpression = member.Expression as ConstantExpression;
        var fieldName = member.Member.Name;
        return validator.IsRequired(rootInstance, constantExpression.Value ?? rootInstance, fieldName);
    }
}
