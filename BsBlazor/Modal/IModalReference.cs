namespace BsBlazor;

public interface IModalReference
{
    Task CloseAsync();
    Task CloseAsync<TResult>(TResult result);
    Task WaitClosedAsync();
    Task<TResult> WaitClosedAsync<TResult>();
}

public interface IModalReference<TResult>
{
    Task<TResult> WaitClosedAsync();
    Task CloseAsync(TResult? result = default);
}