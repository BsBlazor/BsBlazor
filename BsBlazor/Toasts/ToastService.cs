using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ToastService : IToastService
{
    public event Action<ToastReference>? OnToastAdded;
    public event Action<ToastReference>? OnToastRemoved;
    
    public List<ToastReference> ToastReferences { get; private set; } = [];
    
    public async Task<IToastReference> ShowAsync(string message, string? title = null, ToastOptions? options = null)
    {
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.Standalone,
            Message = message,
            Title = title,
            Options = options ?? new ToastOptions()
        };
        
        return await ShowAsyncInternal(toastReference);
    }

    public async Task<IToastReference> ShowAsync(RenderFragment toastContent, ToastOptions? options = null)
    {
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.RenderFragment,
            RenderFragment = toastContent,
            Options = options ?? new ToastOptions()
        };
        
        return await ShowAsyncInternal(toastReference);
    }

    public async Task<IToastReference> ShowAsync(RenderFragment<IToastReference> toastContent, ToastOptions? options = null)
    {
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.ContextualRenderFragment,
            ContextualRenderFragment = toastContent,
            Options = options ?? new ToastOptions()
        };
        
        return await ShowAsyncInternal(toastReference);
    }

    public async Task<IToastReference> ShowAsync<TContentComponent>(
        ToastOptions? options = null,
        Action<ToastComponentParameters<TContentComponent>>? parameters = null)
    {
        var p = new ToastComponentParameters<TContentComponent>();
        parameters?.Invoke(p);
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.Component,
            ToastContentType = typeof(TContentComponent),
            Options = options ?? new ToastOptions(),
            Parameters = p.Parameters
        };
        return await ShowAsyncInternal(toastReference);
    }

    private async Task<IToastReference> ShowAsyncInternal(ToastReference reference)
    {
        ToastReferences.Add(reference);
        OnToastAdded?.Invoke(reference);
        reference.OnHidden += () =>
        {
            ToastReferences.Remove(reference);
            OnToastRemoved?.Invoke(reference);
        };
        // The API would be ready for some async call
        await Task.CompletedTask;
        return reference;
    }
}