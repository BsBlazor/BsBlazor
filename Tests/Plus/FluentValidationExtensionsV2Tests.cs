using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using System.Linq.Expressions;

namespace BsBlazor.Tests.Plus;

public class FluentValidationExtensionsV2Tests
{
    [Fact]
    public void MemberTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        validator.IsRequired(model, model, "Name").Should().BeTrue();
    }

    [Fact]
    public void MemberExpressionTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        Expression<Func<string>> valueExpression = () => model.Name;
        validator.IsRequired(model, valueExpression).Should().BeTrue();
    }

    [Fact]
    public void ChildMemberTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        Expression<Func<string>> valueExpression = () => model.Child.ChildName;
        validator.IsRequired(model, valueExpression).Should().BeTrue();
    }

    [Fact]
    public void ChildIndirectExpressionMemberTest()
    {
        var validator = new ModelValidator();
        var model = new Model();
        var child = model.Child;
        Expression<Func<string>> valueExpression = () => child.ChildName;
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

    [Fact]
    public void InlineComplexTest()
    {
        var validator = new ModelInlineValidator();
        var model = new Model();
        validator.IsRequired(model, () => model.Child.ChildName).Should().BeTrue();
    }

    [Fact]
    public void InlineComplexCollectionTest()
    {
        var validator = new ModelInlineCollectionValidator();
        var model = new Model();
        model.Children.Add(new Child());
        model.Children.Add(new Child());
        validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Children[1].ChildName)
            .WithErrorCode("NotEmptyValidator");
        // 
        validator.IsRequired(model, model.Children[0], "ChildName").Should().BeFalse();
        validator.IsRequired(model, model.Children[1], "ChildName").Should().BeTrue();

    }

    internal class ModelInlineValidator : TrackRequiredValidator<Model>
    {
        public ModelInlineValidator()
        {
            RuleFor(x => x.Child.ChildName).NotEmpty();
        }
    }

    internal class ModelInlineCollectionValidator : TrackRequiredValidator<Model>
    {
        public ModelInlineCollectionValidator()
        {
            RuleFor(x => x.Children[1].ChildName).NotEmpty();
        }
    }

    public string Name { get; set; } = string.Empty;
    internal class SelfValidator : TrackRequiredValidator<FluentValidationExtensionsV2Tests> 
    {
        public SelfValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithState((r, val, ctx) => {
                
                return null;
            });
        }
    }

    internal class ModelValidator : TrackRequiredValidator<Model> 
    {
        public ModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().When(x => true);
            RuleFor(x => x.Child).SetValidator(new ChildValidator());
            RuleForEach(x => x.Children).SetValidator(m => new ChildByIndexValidator(m));
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

    internal class ChildByIndexValidator : TrackRequiredValidator<Child>
    {
        public ChildByIndexValidator(Model model)
        {
            RuleFor(x => x.ChildName).NotEmpty()
                                     .When(x => model.Children.LastOrDefault() == x);
        }
    }

    internal class ChildValidator : TrackRequiredValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(x => x.ChildName).NotEmpty().When(c => true);
        }
    }
}