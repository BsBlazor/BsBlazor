namespace BlazorDevKit;

public class BdkIMaskNumberData
{
    public char Radix { get; set; }
    public string ThousandsSeparator { get; set; } = "";
    public char[] MapToRadix { get; set; } = [];
    public decimal Min { get; set; }
    public decimal Max { get; set; }
    public int Scale { get; set; }
    public bool NormalizeZeros { get; set; }
    public bool PadFractionalZeros { get; set; }
}