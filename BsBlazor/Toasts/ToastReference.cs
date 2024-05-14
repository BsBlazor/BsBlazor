using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ToastReference : IToastReference
{
    private readonly TaskCompletionSource<object?> _resultCompletion = new();
    private BsToast? _toast;
    
    internal event Action? OnHidden;
    
    internal Type? ToastContentType { get; init; }
    internal Dictionary<string, object?> Parameters { get; init; } = [];
    internal RenderFragment? RenderFragment { get; init; }
    internal RenderFragment<IToastReference>? ContextualRenderFragment { get; init; }
    
    internal string? Message { get; init; }
    internal string? Title { get; init; }
    
    internal required ToastReferenceType ReferenceType { get; init; }
    internal required ToastOptions Options { get; init; }
    
    internal void InvokeHidden()
    {
        OnHidden?.Invoke();
        _resultCompletion.TrySetResult(default);
    }
    
    internal void Initialize(BsToast toast)
    {
        if (_toast is not null) { return; }
        _toast = toast;
    }
    
    public async Task CloseAsync()
    {
        _resultCompletion.TrySetResult(null);
        await _toast!.HideAsync();
    }

    public async Task CloseAsync<TResult>(TResult result)
    {
        _resultCompletion.TrySetResult(result);
        await _toast!.HideAsync();
    }

    public async Task WaitClosedAsync() => await _resultCompletion.Task;

    public async Task<TResult> WaitClosedAsync<TResult>()
    {
        var obj = await _resultCompletion.Task;
        if(obj is null) { return default!; }
        return (TResult)obj;
    }
}