namespace BsBlazor;
public interface IModalService
{
    Task<IModalReference> ShowDialogAsync<TDialogComponent>();
}
