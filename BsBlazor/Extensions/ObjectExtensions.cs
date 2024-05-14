namespace BsBlazor.Extensions;

internal static class ObjectExtensions
{
    public static bool IsNotNull<T>(this T obj) => !IsNullInternal(obj);
    public static bool IsNull<T>(this T obj) => IsNullInternal(obj);
    private static bool IsNullInternal(object? obj) => obj is null;
}
