using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDevKit;
public class BdkIMaskNumber<T> : BdkIMaskBase<T>
{
    protected override string IMaskType => "Number";
    // Defaults from https://github.com/uNmAnNeR/imaskjs/blob/master/packages/imask/src/masked/number.ts
    [Parameter] public char Radix { get; set; } = ',';
    [Parameter] public char? ThousandsSeparator { get; set; } // no separator as default
    [Parameter] public IEnumerable<char> MapToRadix { get; set; } = ['.'];
    [Parameter] public decimal Min { get; set; } = -9007199254740991; // Number.MIN_SAFE_INTEGER
    [Parameter] public decimal Max { get; set; } = 9007199254740991; // Number.MAX_SAFE_INTEGER
    [Parameter] public int Scale { get; set; } = 2;
    /// <summary>
    /// Remove leading and trailing zeros in the end of editing
    /// </summary>
    [Parameter] public bool NormalizeZeros { get; set; } = true;
    /// <summary>
    /// Pad fractional zeros in the end of editing
    /// </summary>
    [Parameter] public bool PadFractionalZeros { get; set; } = false;

    [JSInvokable]
    public BdkIMaskNumberData GetData() => new BdkIMaskNumberData
    {
        Radix = Radix,
        ThousandsSeparator = ThousandsSeparator?.ToString() ?? "",
        MapToRadix = MapToRadix.ToArray(),
        Min = Min,
        Max = Max,
        Scale = Scale,
        NormalizeZeros = NormalizeZeros,
        PadFractionalZeros = PadFractionalZeros
    };
}
