using FluentAssertions;
using FluentValidation;

namespace BsBlazor.Tests.Plus.FluentValidation.Incidents.ListVsItemProblem;
public class ListVsItemProblemTest
{
    [Fact]
    public void IncidentTest()
    {
        var request = new Request();
        request.People.Add(new Person());
        var validator = new RequestValidator();
        request.People.First().HasPartner = true;
        validator.IsRequired(request, () => request.People[0].Partner.Name).Should().BeTrue();
    }

}

public class Request
{
    public bool? HasPeople { get; set; }
    public List<Person> People { get; set; } = [];
}
public class RequestValidator: AbstractValidator<Request>
{
    public RequestValidator()
    {
        RuleFor(x => x.HasPeople).NotNull();
        RuleForEach(x => x.People).SetValidator(new PersonValidator());
    }
}

public class Person
{
    public bool HasPartner { get; set; }
    public string Name { get; set; } = "";
    public Partner Partner { get; set; } = new();
}

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleForEach(x => x.Name).NotEmpty();
        RuleFor(x => x.Partner).SetValidator(new PartnerValidator()).When(p => p.HasPartner);
    }
}

public class Partner
{
    public string? ID { get; set; }
    public string? Name { get; set; }
}

public class PartnerValidator : AbstractValidator<Partner>
{
    public PartnerValidator()
    {
        RuleFor(x => x.ID).NotEmpty();
        RuleFor(x => x.Name).MaximumLength(200).NotEmpty();
    }
}