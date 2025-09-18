using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BsBlazor;

public partial class BsModalServiceContainer : IDisposable
{
    private readonly List<ModalReference> _modalReferences = [];
    
    private ModalService ModalServiceImpl => ModalService as ModalService ?? throw new InvalidOperationException("ModalService not registered.");
    
    [Inject] public required IModalService ModalService {get; init;} 
    [Inject] public required NavigationManager NavigationManager {get; init;}
    
    internal bool Disposed { get; private set; }

    internal void Add(ModalReference modalReference) => _modalReferences.Add(modalReference);
    internal bool Remove(ModalReference modalReference) => _modalReferences.Remove(modalReference);
    internal void Clear() => _modalReferences.Clear();
    internal ModalReference[] GetModalReferences() => [.. _modalReferences];


    
    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += LocationChanged;
        ModalServiceImpl.OnModalAdded += _ => StateHasChanged();
        ModalServiceImpl.OnModalRemoved += _ => StateHasChanged();
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
        NavigationManager.LocationChanged -= LocationChanged;
        GC.SuppressFinalize(this);
    }

}