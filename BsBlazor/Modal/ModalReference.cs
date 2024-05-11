namespace BsBlazor;

internal class ModalReference : IModalReference
{
    private readonly TaskCompletionSource<object?> _resultCompletion = new();
    private BsModalRoot? _modalRoot;
    internal event Action? OnHidden;
    internal required Type DialogType { get; init; }
    internal virtual Type ResultType => typeof(object);
    internal void InvokHidden()
    {
        OnHidden?.Invoke();
        _resultCompletion.TrySetResult(default);
    }
    internal void Initialize(BsModalRoot modalRoot)
    {
        if (_modalRoot != null) { return; }
        _modalRoot = modalRoot;
    }
    public async Task CloseAsync()
    {
        _resultCompletion.TrySetResult(null);
        await _modalRoot!.HideAsync();
    }
    public async Task CloseAsync<TResult>(TResult result)
    {
        _resultCompletion.TrySetResult(result);
        await _modalRoot!.HideAsync();
    }
    public async Task WaitClosedAsync()
    {
        await _resultCompletion.Task;
    }
    public async Task<TResult> WaitClosedAsync<TResult>()
    {
        var obj = await _resultCompletion.Task;
        return (TResult)obj!;
    }
}

internal class ModalReference<TResult> : ModalReference, IModalReference<TResult>
{
    internal override Type ResultType => typeof(TResult);

    public async Task CloseAsync(TResult? result = default)
    {
        await ((IModalReference)this).CloseAsync(result);
    }

    async Task<TResult> IModalReference<TResult>.WaitClosedAsync()
    {
        return await((IModalReference)this).WaitClosedAsync<TResult>();
    }
}

//internal class ModalReference : ModalReference<object>, IModalReference
//{
//    public async Task WaitClosedAsync()
//    {
//        await _resultCompletion.Task;
//    }

//    public async Task<TResult> WaitClosedAsync<TResult>()
//    {
//        var obj = await _resultCompletion.Task;
//        return (TResult)obj!;
//    }

//    public async Task CloseAsync<TResult>(TResult? result = default)
//    {
//        await ((IModalReference<object>)this).CloseAsync(result);
//    }
//}


//internal class ModalReference<TResult> : IModalReference<TResult>
//{
//    protected readonly TaskCompletionSource<object?> _resultCompletion = new();
//    private BsModalRoot? _modalRoot;
//    internal event Action? OnHidden;
//    internal required Type DialogType { get; init; }
//    internal void InvokHidden()
//    {
//        OnHidden?.Invoke();
//        _resultCompletion.TrySetResult(default);
//    }
//    internal void Initialize(BsModalRoot modalRoot)
//    {
//        if (_modalRoot != null) { return; }
//        _modalRoot = modalRoot;
//    }

//    async Task<TResult> IModalReference<TResult>.WaitClosedAsync()
//    {
//        var obj = await _resultCompletion.Task;
//        return (TResult)obj!;
//    }

//    public async Task CloseAsync(TResult? result = default)
//    {
//        _resultCompletion.TrySetResult(result);
//        await _modalRoot!.HideAsync();
//    }
//}