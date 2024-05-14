namespace BsBlazor;

public interface IToastReference
{
    Task CloseAsync();
    Task CloseAsync<TResult>(TResult result);
    Task WaitClosedAsync();
    Task<TResult> WaitClosedAsync<TResult>();
}