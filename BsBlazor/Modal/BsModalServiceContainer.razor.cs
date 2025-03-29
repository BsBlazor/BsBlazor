using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BsBlazor;
public partial class BsModalServiceContainer(IModalService modalService, NavigationManager navigationManager) : IDisposable
{
    private readonly List<ModalReference> _modalReferences = [];
    private readonly ModalService _modalService = modalService as ModalService ?? throw new InvalidOperationException("ModalService not registered.");
    internal bool Disposed { get; private set; }


    internal void Add(ModalReference modalReference) => _modalReferences.Add(modalReference);
    internal bool Remove(ModalReference modalReference) => _modalReferences.Remove(modalReference);
    internal void Clear() => _modalReferences.Clear();
    internal ModalReference[] GetModalReferences() => [.. _modalReferences];


    
    protected override void OnInitialized()
    {
        navigationManager.LocationChanged += LocationChanged;
        _modalService.OnModalAdded += (modalReference) => StateHasChanged();
        _modalService.OnModalRemoved += (modalReference) => StateHasChanged();
    }

    private void LocationChanged(object? sender, LocationChangedEventArgs args)
    {
        try
        {
            // Close all modals on navigation.
            // The modals will be removed from the container and disposed,
            // so we don't want to call the "hide" method on them as it may conflict with the disposal.
            // But yet we need to invoke the hidden event for the consumers.
            foreach (var modalReference in GetModalReferences())
            {
                modalReference.InvokeHidden();
            }
            Clear();
        }
        catch (Exception ex)
        {
            // Log?
            Console.WriteLine("ModalService - Error when closing all dialogs on navigation: " + ex.Message);
        }
    }

    public void Dispose()
    {
        Disposed = true;
        navigationManager.LocationChanged -= LocationChanged;
        GC.SuppressFinalize(this);
    }

}