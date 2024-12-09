using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorDevKit;

public partial class BdkFluentValidator<TRequest>
{
    internal const string EditContextKey = "BdkFluentValidator";
    /// <summary>
    /// Elements in child content are guaranteed to have all set up for using IsFluentValidationRequired
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter, EditorRequired] public required IValidator<TRequest> Validator { get; set; }
    [CascadingParameter] private EditContext? EditContext { get; set; }

    private ValidationMessageStore _validationMessageStore = default!;
    
    protected override void OnInitialized()
    {
        if (EditContext is null) { throw new InvalidOperationException("EditContext not found for KitFluentValidator. Make sure you're using inside a EditContext scope like inside an EditForm component."); }
        EditContext.Properties[EditContextKey] = new BdkFluentValidatorContext
        {
            IsRequired = (fieldIdentifier) => Validator.IsRequired(EditContext.Model as TRequest, fieldIdentifier.Model, fieldIdentifier.FieldName)
        };
        _validationMessageStore = new ValidationMessageStore(EditContext);
        EditContext.OnValidationRequested += (sender, eventArgs) => ValidateModel();
        EditContext.OnFieldChanged += (sender, eventArgs) => ValidateModel(validateSingleField: eventArgs.FieldIdentifier);
    }

    private void ValidateModel(FieldIdentifier? validateSingleField = null)
    {
        if (Validator is null) { return; }
        EditContext!.NotifyValidationStateChanged();
        if (EditContext!.Model is not TRequest model)
        {
            throw new InvalidCastException($"EditContext Model is not of type {typeof(TRequest).Name} used for the FluentValidator type in BdkFluentValidator");
        }
        CollectMessages(Validator, model, validateSingleField, _validationMessageStore);
        EditContext.NotifyValidationStateChanged();
        StateHasChanged();
    }

    internal static void CollectMessages<TModel>(
        IValidator<TModel> validator,
        TModel model,
        FieldIdentifier? validateSingleField,
        ValidationMessageStore validationMessageStore
    )
    {
        var validationFailures = validator.Validate(model).Errors;
        if (validateSingleField.HasValue)
        {
            validationMessageStore.Clear(validateSingleField.Value);
        }
        else
        {
            validationMessageStore.Clear();
        }
        foreach (var validationError in validationFailures)
        {
            GetParentObjectAndPropertyName(model, validationError.PropertyName, out object? parentObject, out string propertyName);
            if (parentObject != null)
            {
                var fieldIdentifier = new FieldIdentifier(parentObject, propertyName);
                if (validateSingleField.HasValue)
                {
                    if (validateSingleField.Equals(fieldIdentifier))
                    {
                        validationMessageStore.Add(validateSingleField.Value, validationError.ErrorMessage);
                    }
                }
                else
                {
                    validationMessageStore.Add(fieldIdentifier, validationError.ErrorMessage);
                }
            }
        }

    }

    private static void GetParentObjectAndPropertyName(
          object model,
          string propertyPath,
          out object? parentObject,
          out string propertyName)
    {
        var propertyPathParts = new Queue<string>(propertyPath.Split('.'));
        while (propertyPathParts.Count > 1)
        {
            Type modelType = model.GetType();
            string name = propertyPathParts.Dequeue();

            string? propertyIndexString = null;
            int bracketIndex = name.IndexOf('[');
            if (bracketIndex > 0)
            {
                propertyIndexString = name.Substring(bracketIndex + 1, name.Length - bracketIndex - 2);
                name = name.Remove(bracketIndex);
            }

            var propertyInfo = modelType.GetProperty(name)!;

            model = (model == null
                ? null
                : propertyInfo.GetValue(model, null))!;

            if (propertyIndexString == null)
                modelType = propertyInfo.PropertyType;
            else
            {
                List<object> collection = ((IEnumerable<object>)model!).ToList();
                int propertyIndex = int.Parse(propertyIndexString);
                model = collection[propertyIndex];
            }
        }

        parentObject = model;
        propertyName = propertyPathParts.Dequeue();
    }
}