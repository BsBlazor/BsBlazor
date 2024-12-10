//using FluentAssertions;
//using FluentValidation;
//using FluentValidation.TestHelper;
//using System.Linq.Expressions;

//namespace BsBlazor.Tests.Plus;
//public class FluentValidationExtensionsTests
//{
//    [Fact]
//    public void MemberTest()
//    {
//        var validator = new ModelValidator();
//        var model = new Model();
//        validator.IsRequired(model, model, "Name").Should().BeTrue();
//    }

//    [Fact]
//    public void MemberExpressionTest()
//    {
//        var validator = new ModelValidator();
//        var model = new Model();
//        Expression<Func<string>> valueExpression = () => model.Name;
//        validator.IsRequired(model, valueExpression).Should().BeTrue();
//    }

//    [Fact]
//    public void ChildMemberTest()
//    {
//        var validator = new ModelValidator();
//        var model = new Model();
//        Expression<Func<string>> valueExpression = () => model.Child.ChildName;
//        validator.IsRequired(model, valueExpression).Should().BeTrue();
//    }

//    [Fact]
//    public void ChildIndirectExpressionMemberTest()
//    {
//        var validator = new ModelValidator();
//        var model = new Model();
//        var child = model.Child;
//        Expression<Func<string>> valueExpression = () => child.ChildName;
//        validator.IsRequired(model, valueExpression).Should().BeTrue();
//    }

//    [Fact]
//    public void SelfTest()
//    {
//        var validator = new SelfValidator();
//        validator.IsRequired(this, this, "Name").Should().BeTrue();
//    }

//    [Fact]
//    public void SelfExpressionTest()
//    {
//        var validator = new SelfValidator();
//        Expression<Func<string>> valueExpression = () => Name;
//        validator.IsRequired(this, valueExpression).Should().BeTrue();
//    }

//    [Fact]
//    public void ComplexChildrenValidatorTest()
//    {
//        var validator = new ModelValidator();
//        var model = new Model();
//        model.Children.Add(new Child());
//        model.Children.Add(new Child());
//        validator.IsRequired(model, model.Children[0], "ChildName").Should().BeFalse();
//        validator.IsRequired(model, model.Children[1], "ChildName").Should().BeTrue();
//    }

//    [Fact]
//    public void InlineComplexTest()
//    {
//        var validator = new ModelInlineValidator();
//        var model = new Model();
//        validator.IsRequired(model, () => model.Child.ChildName).Should().BeTrue();
//    }

//    [Fact]
//    public void NotCurrentlySupported_InlineComplexCollectionTest()
//    {
//        var validator = new ModelInlineCollectionValidator();
//        var model = new Model();
//        model.Children.Add(new Child());
//        model.Children.Add(new Child());
//        validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Children[1].ChildName)
//            .WithErrorCode("NotEmptyValidator");
//        validator.IsRequired(model, model.Children[1], "ChildName").Should().BeFalse();

//    }

//    public class ModelInlineValidator: AbstractValidator<Model>
//    {
//        public ModelInlineValidator()
//        {
//            RuleFor(x => x.Child.ChildName).NotEmptyTrackRequired();
//        }
//    }

//    public class ModelInlineCollectionValidator : AbstractValidator<Model>
//    {
//        public ModelInlineCollectionValidator()
//        {
//            RuleFor(x => x.Children[1].ChildName).NotEmptyTrackRequired();
//        }
//    }

//    public string Name { get; set; } = string.Empty;
//    public class SelfValidator : AbstractValidator<FluentValidationExtensionsTests>
//    {
//        public SelfValidator()
//        {
//            RuleFor(x => x.Name).NotEmptyTrackRequired();
//        }
//    }

//    public class ModelValidator : AbstractValidator<Model> 
//    {
//        public ModelValidator()
//        {
//            RuleFor(x => x.Name).NotEmptyTrackRequired();
//            RuleFor(x => x.Child).SetValidator(new ChildValidator());
//            RuleForEach(x => x.Children).SetValidator(m => new ChildByIndexValidator(m));
//        }
//    }

//    public class Model
//    {
//        public string Name { get; set; } = string.Empty;
//        public Child Child { get; set; } = new Child();
//        public List<Child> Children { get; set; } = new();
//    }

//    public class Child
//    {
//        public Guid Id { get; set; } = Guid.NewGuid();
//        public string ChildName { get; set; } = string.Empty;
//    }

//    public class ChildByIndexValidator: AbstractValidator<Child>
//    {
//        public ChildByIndexValidator(Model model)
//        {
//            RuleFor(x => x.ChildName).NotEmptyTrackRequired()
//                                     .When(x => model.Children.LastOrDefault() == x);
//        }
//    }

//    public class ChildValidator : AbstractValidator<Child> 
//    {
//        public ChildValidator()
//        {
//            RuleFor(x => x.ChildName).NotEmptyTrackRequired().When(c => true);
//        }
//    }
//}