using System.Diagnostics.CodeAnalysis;

namespace BsBlazor.Plus;
#if NET9_0_OR_GREATER
public partial class BspSelectField<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue>(BsBlazorPlusOptions? options = null)
#else
public partial class BspSelectField<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue>
#endif
{
    private string _fakeLoading = "...";
    private InputSelect<TValue?>? _select = default!;
    private string InputCss => CssBuilder.Default("form-select")
         .AddClass("form-select-sm", Size == BsFormControlSize.Small)
         .AddClass("form-select-lg", Size == BsFormControlSize.Large)
         .Build();

    // [Parameter] public RenderFragment? PrependOptions { get; set; } maybe?
    [Parameter] public bool ShowEmptyOption { get; set; } = true;
    [Parameter] public string EmptyOptionText { get; set; } = "";
    [Parameter] public string LoadingText { get; set; } = "...";
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public IEnumerable<(TValue? value, string? text)>? Options { get; set; }
    [Parameter] public Func<Task<IEnumerable<(TValue? value, string? text)>>>? LoadOptions { get; set; }
    [Parameter] public string? PeristentStateKey { get; set; }

    public override ValueTask FocusAsync() => _select != null ? _select.Element!.Value.FocusAsync() : ValueTask.CompletedTask;

    protected override void OnInitialized()
    {
#if NET9_0_OR_GREATER
        EmptyOptionText = options?.SelectField.DefaultEmptyOptionText ?? EmptyOptionText;
        LoadingText = options?.SelectField.DefaultLoadingText ?? LoadingText;
#endif
        base.OnInitialized();
    }
}