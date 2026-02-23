using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ToastService : IToastService
{
    public event Action<ToastReference>? OnToastAdded;
    public event Action<ToastReference>? OnToastRemoved;
    
    public List<ToastReference> ToastReferences { get; private set; } = [];
    internal List<BsToastServiceContainer> Containers { get; private set; } = [];

    public async Task<IToastReference> ShowAsync(string message, string? title = null, ToastOptions? options = null)
    {
        options ??= new ToastOptions();
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.Standalone,
            Message = message,
            Title = title,
            Options = options,
            ContainerRef = Containers[options.ContainerIndex]
        };
        
        return await ShowAsyncInternal(toastReference);
    }

    public async Task<IToastReference> ShowAsync(RenderFragment toastContent, ToastOptions? options = null)
    {
        options ??= new ToastOptions();
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.RenderFragment,
            RenderFragment = toastContent,
            Options = options,
            ContainerRef = Containers[options.ContainerIndex]
        };
        
        return await ShowAsyncInternal(toastReference);
    }

    public async Task<IToastReference> ShowAsync(RenderFragment<IToastReference> toastContent, ToastOptions? options = null)
    {
        options ??= new ToastOptions();
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.ContextualRenderFragment,
            ContextualRenderFragment = toastContent,
            Options = options,
            ContainerRef = Containers[options.ContainerIndex]
        };
        
        return await ShowAsyncInternal(toastReference);
    }

    public async Task<IToastReference> ShowAsync<TContentComponent>(
        ToastOptions? options = null,
        Action<ToastComponentParameters<TContentComponent>>? parameters = null)
    {
        options ??= new ToastOptions();
        var p = new ToastComponentParameters<TContentComponent>();
        parameters?.Invoke(p);
        var toastReference = new ToastReference
        {
            ReferenceType = ToastReferenceType.Component,
            ToastContentType = typeof(TContentComponent),
            Options = options,
            Parameters = p.Parameters,
            ContainerRef = Containers[options.ContainerIndex]
        };
        return await ShowAsyncInternal(toastReference);
    }

    private async Task<IToastReference> ShowAsyncInternal(ToastReference reference)
    {
        ToastReferences.Add(reference);
        OnToastAdded?.Invoke(reference);
        reference.OnHidden += async () =>
        {
            // BS manipulates the toast classes even after calling the Hidden event.
            // If it is removed too quickly it may generate errors in the console
            await Task.Delay(2000);
            ToastReferences.Remove(reference);
            OnToastRemoved?.Invoke(reference);
        };
        // The API would be ready for some async call
        await Task.CompletedTask;
        return reference;
    }
}