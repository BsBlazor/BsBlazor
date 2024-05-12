using Microsoft.AspNetCore.Components;

namespace BsBlazor;

internal class ModalService: IModalService
{
    public event Action<ModalReference>? OnModalAdded;
    public event Action<ModalReference>? OnModalRemoved;
    public List<ModalReference> ModalReferences { get; private set; } = [];

    public async Task<IModalReference> ShowDialogAsync(RenderFragment renderFragment, ModalOptions? modalOptions = null)
    {
        var modalReference = new ModalReference
        {
            RenderFragment = renderFragment,
            ModalOptions = modalOptions ?? new ModalOptions()
        };
        return await ShowDialogAsync(modalReference);
    }


    public async Task<IModalReference> ShowDialogAsync(RenderFragment<IModalReference> contextualRenderFragment, ModalOptions? modalOptions = null)
    {
        var modalReference = new ModalReference
        {
            ContextualRenderFragment = contextualRenderFragment,
            ModalOptions = modalOptions ?? new ModalOptions()
        };
        return await ShowDialogAsync(modalReference);
    }

    public async Task<IModalReference> ShowDialogAsync<TDialogComponent>(ModalOptions? modalOptions = null)
    {
        var modalReference = new ModalReference
        {
            DialogType = typeof(TDialogComponent),
            ModalOptions = modalOptions ?? new ModalOptions()
        };
       return await ShowDialogAsync(modalReference);
    }

    private async Task<IModalReference> ShowDialogAsync(ModalReference modalReference)
    {
        ModalReferences.Add(modalReference);
        OnModalAdded?.Invoke(modalReference);
        modalReference.OnHidden += () =>
        {
            ModalReferences.Remove(modalReference);
            OnModalRemoved?.Invoke(modalReference);
        };
        // The API would be ready for some async call
        await Task.CompletedTask;
        return modalReference;
    }
}
