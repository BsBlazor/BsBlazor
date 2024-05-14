using Microsoft.AspNetCore.Components;

namespace BsBlazor;

public interface IToastService
{
    Task<IToastReference> ShowAsync(string message, string? title = null, ToastOptions? options = null);
    
    Task<IToastReference> ShowAsync(RenderFragment toastContent, ToastOptions? options = null);
    Task<IToastReference> ShowAsync(RenderFragment<IToastReference> toastContent, ToastOptions? options = null);
    Task<IToastReference> ShowAsync<TContentComponent>(ToastOptions? options = null, Action<ToastComponentParameters<TContentComponent>>? parameters = null);
}