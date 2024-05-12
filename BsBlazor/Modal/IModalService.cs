using Microsoft.AspNetCore.Components;

namespace BsBlazor;
public interface IModalService
{
    Task<IModalReference> ShowDialogAsync<TDialogComponent>();
    Task<IModalReference> ShowDialogAsync(RenderFragment renderFragment);
    Task<IModalReference> ShowDialogAsync(RenderFragment<IModalReference> contextualRenderFragment);
}
