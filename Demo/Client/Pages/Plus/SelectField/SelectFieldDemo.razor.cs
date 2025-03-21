namespace BsBlazor.Demo.Client.Pages.Plus.SelectField;
public partial class SelectFieldDemo
{
    private const string ProgramCode = """
                                       builder.Services.AddBsBlazorPlusOptions(options =>
                                       {
                                           options.SelectField.DefaultEmptyOptionText = "Select an option...";
                                           options.SelectField.DefaultLoadingText = "Loading...";
                                       });
                                       """;
}