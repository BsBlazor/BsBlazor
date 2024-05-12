namespace BsBlazor;

public interface IModalReference
{
    Task CloseAsync();
    Task CloseAsync<TResult>(TResult result);
    Task WaitClosedAsync();
    Task<TResult> WaitClosedAsync<TResult>();
}