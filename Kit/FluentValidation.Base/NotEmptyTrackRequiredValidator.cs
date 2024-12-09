using FluentValidation;
using FluentValidation.Validators;

namespace BlazorDevKit.FluentValidation.Base;

public class NotEmptyTrackRequiredValidator<T, TProperty> : NotEmptyValidator<T, TProperty>
{
    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {
        if (context.RootContextData.TryGetValue("Requireds", out object? requiredsInstance) && !base.IsValid(context, default!))
        {
            var requireds = (HashSet<(object model, string fieldName)>)requiredsInstance;
            requireds.Add((context.InstanceToValidate!, context.PropertyPath.Split('.').LastOrDefault("")));
        }
        return base.IsValid(context, value);
    }
}
