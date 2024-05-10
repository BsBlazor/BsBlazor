namespace BsBlazor;

internal class ModalService: IModalService
{
    public event Action<ModalReference>? OnModalAdded;
    public event Action<ModalReference>? OnModalRemoved;
    public List<ModalReference> ModalReferences { get; private set; } = [];


    public async Task<IModalReference> ShowDialogAsync<TDialogComponent>()
    {
        var modalReference = new ModalReference
        {
            DialogType = typeof(TDialogComponent)
        };
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
