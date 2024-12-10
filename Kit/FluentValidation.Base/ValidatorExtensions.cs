using System.Linq.Expressions;

namespace FluentValidation;
public static class ValidatorExtensions
{
    /// <summary>
    /// Check if a field is required by FluentValidation.
    /// This does not support inline collection fields. Use nested validators instead.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="validator"></param>
    /// <param name="rootInstance"></param>
    /// <param name="targetInstance"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
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
        var targetModel = Expression.Lambda(member.Expression!).Compile().DynamicInvoke();
        //var constantExpression = member.Expression as ConstantExpression;
        //member.Expression.
        var fieldName = member.Member.Name;
        return validator.IsRequired(rootInstance, targetModel ?? rootInstance!, fieldName);
    }
}
