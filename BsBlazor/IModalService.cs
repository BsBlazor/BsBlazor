namespace BsBlazor;
public interface IModalService
{
    Task ShowDialogAsync<TDialogComponent>();
}

internal class ModalService : IModalService
{
    public async Task ShowDialogAsync<TDialogComponent>()
    {

    }
}
