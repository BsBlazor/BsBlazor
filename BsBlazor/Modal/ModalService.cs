using Microsoft.AspNetCore.Components;
namespace BsBlazor;
// TODO: review/refactor this service together with the container (BsModalServiceContainer)
internal class ModalService : IModalService
{
    internal BsModalServiceContainer? CurrentContainer { get; set; }
    private BsModalServiceContainer Container => CurrentContainer is not null and not { Disposed: true } ?
                                                 CurrentContainer : throw new InvalidOperationException("<BsModalServiceContainer> not found in the current strcuture.");


    public event Action<ModalReference>? OnModalAdded;
    public event Action<ModalReference>? OnModalRemoved;

    public async Task<IModalReference> ShowDialogAsync(RenderFragment renderFragment, ModalOptions? modalOptions = null)
    {
        var modalReference = new ModalReference
        {
            RenderFragment = renderFragment,
            ModalOptions = modalOptions ?? new ModalOptions()
        };
        return await ShowDialogAsync(modalReference);
    }

    public async Task CloseAllAsync()
    {
        foreach (var modalReference in Container.GetModalReferences())
        {
            await modalReference.CloseAsync();
        }
        Container.Clear();
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

    public async Task<IModalReference> ShowDialogAsync<TDialogComponent>(
        ModalOptions? modalOptions = null,
        Action<DialogComponentParameters<TDialogComponent>>? parameters = null
    )
    {
        var p = new DialogComponentParameters<TDialogComponent>();
        parameters?.Invoke(p);
        var modalReference = new ModalReference
        {
            DialogType = typeof(TDialogComponent),
            ModalOptions = modalOptions ?? new ModalOptions(),
            Parameters = p.Parameters
        };
       return await ShowDialogAsync(modalReference);
    }

    private async Task<IModalReference> ShowDialogAsync(ModalReference modalReference)
    {
        Container.Add(modalReference);
        OnModalAdded?.Invoke(modalReference);
        modalReference.OnHidden += () =>
        {
            Console.WriteLine("Called hidden");
            if (Container.Remove(modalReference))
            {
                OnModalRemoved?.Invoke(modalReference);
            }
        };
        // The API would be ready for some async call
        await Task.CompletedTask;
        return modalReference;
    }
}
