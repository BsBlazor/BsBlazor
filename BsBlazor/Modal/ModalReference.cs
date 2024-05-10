
namespace BsBlazor;

internal class ModalReference : IModalReference
{
    public event Action? OnHidden;
    private BsModalRoot? _modalRoot;
    public required Type DialogType { get; init; }
    public void Initialize(BsModalRoot modalRoot)
    {
        if(_modalRoot != null) { return; }
        _modalRoot = modalRoot;
        //_modalRoot.OnHidden += (e) => { OnHidden?.Invoke() };
    }

    public void InvokHidden()
    {
        OnHidden?.Invoke();
    }
}