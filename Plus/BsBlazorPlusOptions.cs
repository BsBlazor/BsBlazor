#if NET9_0_OR_GREATER
namespace BsBlazor.Plus;
public class BsBlazorPlusOptions
{
    public SelectFieldOptions SelectField { get; private set; } = new();

    public class SelectFieldOptions
    {
        public string? DefaultEmptyOptionText { get; set; }
        public string? DefaultLoadingText { get; set; }
    }
}
#endif