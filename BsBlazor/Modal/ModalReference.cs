using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ModalReference : IModalReference
{
    private readonly TaskCompletionSource<object?> _resultCompletion = new();
    private readonly TaskCompletionSource _hiddenResultCompletion = new();
    private BsModal? _modal;
    internal event Action? OnHidden;
    //internal event Action? OnDispose;
    internal Type? DialogType { get; set; }
    internal Dictionary<string, object?>? Parameters { get; set; }
    internal RenderFragment? RenderFragment { get; set; }
    internal RenderFragment<IModalReference>? ContextualRenderFragment { get; set; }
    internal required ModalOptions ModalOptions { get; init; } = new();
    internal virtual Type ResultType => typeof(object);
    internal void InvokeHidden()
    {
        Console.WriteLine("Invoking hidden");
        OnHidden?.Invoke();
        _resultCompletion.TrySetResult(default);
        _hiddenResultCompletion.TrySetResult();
    }
    internal void Initialize(BsModal modalRoot)
    {
        if (_modal != null) { return; }
        _modal = modalRoot;
    }
    public async Task CloseAsync()
    {
        await _modal!.HideAsync();
        _resultCompletion.TrySetResult(null);
        await HideCompletionAsync();
    }
    public async Task CloseAsync<TResult>(TResult result)
    {
        await _modal!.HideAsync();
        _resultCompletion.TrySetResult(result);
        await HideCompletionAsync();
    }
    public async Task WaitClosedAsync()
    {
        await _resultCompletion.Task;
        await HideCompletionAsync();
    }
    public async Task<TResult> WaitClosedAsync<TResult>()
    {
        var obj = await _resultCompletion.Task;
        await HideCompletionAsync();
        if (obj is null)
        {
            return default!;
        }
        return (TResult)obj!;
    }
    // wait for bootstrap hiding modal completely
    private async Task HideCompletionAsync()
    {
        await _hiddenResultCompletion.Task;
    }
}