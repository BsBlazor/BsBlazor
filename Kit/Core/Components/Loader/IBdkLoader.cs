namespace BlazorDevKit;

public interface IBdkLoader
{
    Task ReloadAsync();
    bool CanRetry { get; }
    string CanRetryTitle { get; }
}