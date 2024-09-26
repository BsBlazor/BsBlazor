using BlazorDevKit;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Validators;
using System.Linq.Expressions;

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
    [Fact]
    public void InlineNewTest()
    {
        var validator = new ModelValidator();
        Expression<Func<string>> valueExpression = () => new Model().Name;
        validator.IsRequired(valueExpression).Should().BeTrue();
    }

    [Fact]
    public void InlineNewChildTest()
    {
        var validator = new ModelValidator();
        Expression<Func<string>> valueExpression = () => new Model().Child.ChildName;
        validator.IsRequired(valueExpression).Should().BeTrue();
    }

    [Fact]
    public void OutsideMemberTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        Expression<Func<string>> valueExpression = () => model.Name;
        validator.IsRequired(valueExpression).Should().BeTrue();
    }

    [Fact]
    public void SelfTest()
    {
        var validator = new SelfValidator();
        Expression<Func<string>> valueExpression = () => Name;
        validator.IsRequired(valueExpression).Should().BeTrue();
    }

    public string Name { get; set; } = string.Empty;
    public class SelfValidator : AbstractValidator<FluentValidationExtensionsTests>
    {
        public SelfValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Child).SetValidator(new ChildValidator());
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
    }

    public class Child
    {
        public string ChildName { get; set; } = string.Empty;
    }

    public class ChildValidator : AbstractValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(x => x.ChildName).NotEmpty();
        }
    }
}
