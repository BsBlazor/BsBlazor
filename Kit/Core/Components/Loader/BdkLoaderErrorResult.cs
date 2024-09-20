namespace BlazorDevKit;

public record BdkLoaderErrorResult(Exception Exception, IBdkLoader Loader)
{
    public Type GetExceptionType() => Exception.GetType();
}