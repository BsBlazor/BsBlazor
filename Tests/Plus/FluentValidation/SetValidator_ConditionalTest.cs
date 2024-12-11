using FluentAssertions;
using FluentValidation;

namespace BsBlazor.Tests.Plus.FluentValidation;
public class SetValidator_ConditionalTest
{
    [Fact]
    public void ShouldValidateTest()
    {
        var model = new Model();
        var validator = new ModelValidator();
        model.ShouldValidateChild = true;
        validator.IsRequired(model, () => model.Child.Name).Should().BeTrue();
    }

    [Fact]
    public void ShouldNotValidateTest()
    {
        var model = new Model();
        var validator = new ModelValidator();
        model.ShouldValidateChild = false;
        validator.IsRequired(model, () => model.Child.Name).Should().BeFalse();
    }

    public class Model 
    { 
        public bool ShouldValidateChild { get; set; }
        public Child Child { get; set; } = new();
    }

    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.Child).SetValidator(new ChildValidator()).When(x => x.ShouldValidateChild);
        }
    }

    public class Child
    {
        public string Name { get; set; } = "";
    }

    public class  ChildValidator: AbstractValidator<Child>
    {
        public ChildValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
