using FluentAssertions;
using FluentValidation;

namespace BsBlazor.Tests.Plus.FluentValidation.Incidents.Fix_2024_12_16;

public class Fix_2024_12_16_Test
{
    [Fact]
    public void IncidentTest()
    {
        var model = new Model();
        var validator = new ModelValidator();
        validator.IsRequired(model, () => model.Field1).Should().BeTrue();
    }
}

public class Model
{
    public string Field1 { get; set; } = default!;
}

public class ModelValidator : AbstractValidator<Model>
{
    public ModelValidator() => Include(new ModelBaseValidator());
}

public class ModelBaseValidator : AbstractValidator<Model>
{
    public ModelBaseValidator() => RuleFor(x => x.Field1).NotEmpty();
}
