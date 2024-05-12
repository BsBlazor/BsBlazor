using Microsoft.AspNetCore.Components;

namespace BsBlazor;
public interface IModalService
{
    Task<IModalReference> ShowDialogAsync<TDialogComponent>(ModalOptions? modalOptions = null);
    Task<IModalReference> ShowDialogAsync(RenderFragment renderFragment, ModalOptions? modalOptions = null);
    Task<IModalReference> ShowDialogAsync(RenderFragment<IModalReference> contextualRenderFragment, ModalOptions? modalOptions = null);
}
