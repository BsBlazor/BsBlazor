using Microsoft.AspNetCore.Components;

namespace BlazorDevKit;

public partial class BdkLoader<TResult> : ComponentBase, IDisposable, IBdkLoader
{
    private readonly string _loaderToken = "BdkLoader" + typeof(TResult).Name;
    private PersistingComponentStateSubscription? _persistingSubscription;
    private TResult? _value;
    private BdkLoaderState _state = BdkLoaderState.Loading;
    private BdkLoaderErrorResult _lastErrorResult = default!;

    [Inject] public required PersistentComponentState PersistentComponentState { get; set; }
    
    [Parameter] public bool PreserveState { get; set; }
    [Parameter] public bool CanRetry { get; set; }
    [Parameter] public string Message { get; set; } = string.Empty;
    [Parameter] public string CanRetryTitle { get; set; } = string.Empty;
    
    [Parameter] [EditorRequired] public required Func<Task<TResult>> Load { get; set; }
    [Parameter] [EditorRequired] public required RenderFragment<TResult> ChildContent { get; set; }
    
    [Parameter] public EventCallback<TResult> OnLoaded { get; set; }
    [Parameter] public EventCallback<BdkLoaderErrorResult> OnError { get; set; }
    
    [Parameter] public RenderFragment? LoadingContent { get; set; }
    [Parameter] public RenderFragment<BdkLoaderErrorResult>? ErrorContent { get; set; }
    
    
    protected override async Task OnInitializedAsync() => await TryLoadAsync();

    private async Task TryLoadAsync()
    {
        try
        {
            if (PreserveState)
            {
                RegisterPersistingAction();
                await LoadOrRestoreAsync();
            }
            else
            {
                await LoadAsync();
            }

            _state = BdkLoaderState.Loaded;
            await OnLoaded.InvokeAsync(_value);
        }
        catch (Exception e)
        {
            _state = BdkLoaderState.Error;
            _lastErrorResult = new BdkLoaderErrorResult(e, this);
            await OnError.InvokeAsync(_lastErrorResult);
        }
        finally
        {
            StateHasChanged();
        }
    }
    
    public async Task ReloadAsync()
    {
        _state = BdkLoaderState.Loading;
        StateHasChanged();
        await TryLoadAsync();
    }
    
    private async Task LoadAsync() => _value = await Load();
    
    private async Task LoadOrRestoreAsync()
    {
        PersistentComponentState.TryTakeFromJson<TResult>(_loaderToken, out var restored);
        _value = restored ?? await Load();
    }
    
    private void RegisterPersistingAction() => _persistingSubscription = PersistentComponentState.RegisterOnPersisting(PersistValue);
    
    private Task PersistValue()
    {
        PersistentComponentState.PersistAsJson(_loaderToken, _value);
        return Task.CompletedTask;
    }
    
    public void Dispose()
    {
        _persistingSubscription?.Dispose();
        GC.SuppressFinalize(this);
    }
}