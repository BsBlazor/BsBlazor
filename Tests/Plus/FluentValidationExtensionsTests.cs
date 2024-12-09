using BlazorDevKit;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using static BsBlazor.Tests.Plus.FluentValidationExtensionsTests;

namespace BsBlazor.Tests.Plus;
public class FluentValidationExtensionsTests
{
    //public class Bdk<T> : AbstractValidator<T>
    //{
    //    protected override void OnRuleAdded(IValidationRule<T> rule)
    //    {
    //        rule.
    //    }
    //}

    //[Fact]
    //public void Bla()
    //{
    //    var validator = new ModelValidator();
    //    //Expression<Func<string>> valueExpression = () => new Model().Name;
    //    var model = new Model();
    //    var fi = FieldIdentifier.Create(() => model.Child.ChildName);
    //    //var result = validator.TrackValidate(new Model()/*, options => options.IncludeProperties("Child.ChildName")*/);
    //    var validationContext = ValidationContext<Model>.CreateWithOptions(model, options => { } /*options.IncludeProperties("Child.ChildName")*/);
    //    validationContext.RootContextData["Requireds"] = new HashSet<(object model, string fieldName)>();
    //    var result = validator.Validate(validationContext);
        
    //    //var va = validator.CreateDescriptor();
    //    //var r1 = va.GetRulesForMember("Name");
    //    //var r2 = va.GetRulesForMember("Child");
    //    //var r3 = va.GetRulesForMember("Child.ChildName");
    //}

    //private static class FluentValidatorBlas
    //{

    //}


    //[Fact]
    //public void InlineNewTest()
    //{
    //    var validator = new ModelValidator();
    //    Expression<Func<string>> valueExpression = () => new Model().Name;
    //    validator.IsRequired(valueExpression).Should().BeTrue();
    //}

    //[Fact]
    //public void InlineNewChildTest()
    //{
    //    var validator = new ModelValidator();
    //    Expression<Func<string>> valueExpression = () => new Model().Child.ChildName;
    //    validator.IsRequired(valueExpression).Should().BeTrue();
    //}

    [Fact]
    public void OutsideMemberTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        validator.IsRequired(model, model, "Name").Should().BeTrue();
    }

    [Fact]
    public void OutsideMemberExpressionTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        Expression<Func<string>> valueExpression = () => model.Name;
        validator.IsRequired(model, valueExpression).Should().BeTrue();
    }

    [Fact]
    public void SelfTest()
    {
        var validator = new SelfValidator();
        validator.IsRequired(this, this, "Name").Should().BeTrue();
    }

    [Fact]
    public void SelfExpressionTest()
    {
        var validator = new SelfValidator();
        Expression<Func<string>> valueExpression = () => Name;
        validator.IsRequired(this, valueExpression).Should().BeTrue();
    }

    [Fact]
    public void ComplexChildrenValidatorTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        model.Children.Add(new Child());
        model.Children.Add(new Child());
        validator.IsRequired(model, model.Children[0], "ChildName").Should().BeFalse();
        validator.IsRequired(model, model.Children[1], "ChildName").Should().BeTrue();
    }

    public string Name { get; set; } = string.Empty;
    public class SelfValidator : AbstractValidator<FluentValidationExtensionsTests> // TrackingValidator<FluentValidationExtensionsTests>
    {
        public SelfValidator()
        {
            RuleFor(x => x.Name).NotEmptyTrackRequired();
        }
    }

    public class ModelValidator : AbstractValidator<Model> // TrackingValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.Name).NotEmptyTrackRequired();
            RuleFor(x => x.Child).SetValidator(new ChildValidator());
            RuleForEach(x => x.Children).SetValidator(m => new ChildByIndexValidator(m));
        }

        protected override void OnRuleAdded(IValidationRule<Model> rule)
        {
            base.OnRuleAdded(rule);
        }
    }

    public class Model
    {
        public string Name { get; set; } = string.Empty;
        public Child Child { get; set; } = new Child();
        public List<Child> Children { get; set; } = new();
    }

    public class Child
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ChildName { get; set; } = string.Empty;
    }

    public class ChildByIndexValidator: AbstractValidator<Child>
    {
        public ChildByIndexValidator(Model model)
        {
            RuleFor(x => x.ChildName).NotEmptyTrackRequired()
                                     .When(x => model.Children.LastOrDefault() == x);
        }
    }

    public class ChildValidator : AbstractValidator<Child> // TrackingValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(x => x.ChildName).NotEmptyTrackRequired().When(c => true);
        }
    }

    //public class TrackingValidator<T> : AbstractValidator<T>
    //{
    //    public Dictionary<object, ValidationResult> TrackValidate(T instance, Action<ValidationStrategy<T>>? options = null)
    //    {
    //        Validate(options == null ? new ValidationContext<T>(instance) : ValidationContext<T>.CreateWithOptions(instance, options));
    //        return new();
    //    }

    //    public override ValidationResult Validate(ValidationContext<T> context)
    //    {
    //        var validatonResult = base.Validate(context);

    //        return validatonResult;
    //    }

    //    protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
    //    {
    //        var pre = base.PreValidate(context, result);
    //        return pre;
    //    }
    //    public override async Task<ValidationResult> ValidateAsync(ValidationContext<T> context, CancellationToken cancellation = default)
    //    { 
    //        var result = await base.ValidateAsync(context, cancellation);
    //        return result;
    //    }

    //    protected override void OnRuleAdded(IValidationRule<T> rule)
    //    {
    //        base.OnRuleAdded(rule);
    //    }
    //}

    //public class SpecialNotEmptyValidator<T, TProperty> : NotEmptyValidator<T, TProperty>
    //{
    //    public override bool IsValid(ValidationContext<T> context, TProperty value)
    //    {
    //        var isRequired = !base.IsValid(context, default!);
    //        if (isRequired)
    //        {
    //            var requireds = (HashSet<(object model, string fieldName)>)context.RootContextData["Requireds"];
    //            requireds.Add((context.InstanceToValidate!, context.PropertyPath.Split('.').LastOrDefault("")));
    //        }
    //        return base.IsValid(context, value);
    //    }
    //}
}


//static class Specials
//{
//    public static IRuleBuilderOptions<T, TProperty> SpecialNotEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
//    => ruleBuilder.SetValidator(new SpecialNotEmptyValidator<T, TProperty>());

//}