namespace BsBlazor;

public class StandaloneToastData
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public required ToastOptions Options { get; set; }
}