using Microsoft.AspNetCore.Components.Forms;

namespace BlazorDevKit;

public class BdkFluentValidatorContext
{
    public required Func<FieldIdentifier, bool> IsRequired { get; init; }
}
