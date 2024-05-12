using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ModalReference : IModalReference
{
    private readonly TaskCompletionSource<object?> _resultCompletion = new();
    private BsModal? _modal;
    internal event Action? OnHidden;
    internal Type? DialogType { get; set; }
    internal RenderFragment? RenderFragment { get; set; }
    internal RenderFragment<IModalReference>? ContextualRenderFragment { get; set; }
    internal required ModalOptions ModalOptions { get; init; } = new();
    internal virtual Type ResultType => typeof(object);
    internal void InvokHidden()
    {
        OnHidden?.Invoke();
        _resultCompletion.TrySetResult(default);
    }
    internal void Initialize(BsModal modalRoot)
    {
        if (_modal != null) { return; }
        _modal = modalRoot;
    }
    public async Task CloseAsync()
    {
        _resultCompletion.TrySetResult(null);
        await _modal!.HideAsync();
    }
    public async Task CloseAsync<TResult>(TResult result)
    {
        _resultCompletion.TrySetResult(result);
        await _modal!.HideAsync();
    }
    public async Task WaitClosedAsync()
    {
        await _resultCompletion.Task;
    }
    public async Task<TResult> WaitClosedAsync<TResult>()
    {
        var obj = await _resultCompletion.Task;
        if(obj is null)
        {
            return default!;
        }
        return (TResult)obj!;
    }
}