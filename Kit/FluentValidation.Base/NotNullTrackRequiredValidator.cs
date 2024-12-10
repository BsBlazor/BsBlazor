//using FluentValidation;
//using FluentValidation.Validators;

//namespace BlazorDevKit.FluentValidation.Base;

//public class NotNullTrackRequiredValidator<T, TProperty> : NotNullValidator<T, TProperty>
//{
//    public override bool IsValid(ValidationContext<T> context, TProperty value)
//    {
//        RequiredTracker.VerifyRequired<T, TProperty>(base.IsValid, context);
//        return base.IsValid(context, value);
//    }
//}