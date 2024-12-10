using BlazorDevKit;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

namespace BsBlazor.Tests.Plus.FluentValidation;
public class BdkFluentValidatorListTests
{
    [Fact]
    public void Test()
    {
        var validator = new Validator();
        var model = new Model();
        var validationMessageStore = new ValidationMessageStore(new EditContext(model));
        var fieldIdentificar = FieldIdentifier.Create(() => model.Childs);
        BdkFluentValidator<Model>.CollectMessages(validator, model, fieldIdentificar, validationMessageStore);
    }

    class Model
    {
        public string Name { get; set; } = string.Empty;
        public Child Child { get; set; } = new Child();
        public List<Child> Childs { get; set; } = [];
    }

    class Child
    {
        public string ChildName { get; set; } = string.Empty;
    }

    class Validator : AbstractValidator<Model>
    {
        public Validator()
        {
            RuleFor(x => x.Childs).NotEmpty().WithMessage("X");
        }
    }
}
