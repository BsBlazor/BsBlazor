using System.Linq.Expressions;

namespace BsBlazor;

public class DialogComponentParameters<TComponent> 
{
    internal Dictionary<string, object?> Parameters { get; private set; } = [];
    public DialogComponentParameters<TComponent> Add<TParameter>(Expression<Func<TComponent, TParameter>> propertyExpression, TParameter value)
    {
        if (propertyExpression.Body is not MemberExpression memberExpression)
        {
            throw new ArgumentException($"Argument '{nameof(propertyExpression)}' must be a '{nameof(MemberExpression)}'");
        }
        Parameters[memberExpression.Member.Name] = value;
        return this;
    }
}