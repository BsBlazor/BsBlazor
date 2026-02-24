namespace BlazorDevKit;

public class BdkIMaskValues<T>
{
    public string MaskedValue { get; set; } = string.Empty;
    public string UnmaskedValue { get; set; } = string.Empty;
    public T? TypedValue { get; set; }
}