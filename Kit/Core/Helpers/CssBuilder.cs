using System.Text;

namespace BlazorDevKit.Helpers;

internal sealed class CssBuilder
{
    private readonly StringBuilder _buffer = new();
    
    public static CssBuilder Default(string value) => new(value);
    public static CssBuilder Empty() => new(string.Empty);
    private CssBuilder(string value) => _buffer.Append(value);
    
    private CssBuilder AddValue(string? value)
    {
        _buffer.Append(value);
        return this;
    }
    
    private CssBuilder AddClass(string? value) => value is null ? this : AddValue(" " + value);
    public CssBuilder AddClass(string? value, bool when) => when ? AddClass(value) : this;
    public CssBuilder AddClass(string? value, bool? when) => when is true ? AddClass(value) : this;
    public string Build() => _buffer.ToString().Trim();
    public static implicit operator string(CssBuilder builder) => builder.Build();
    public override string ToString() => Build();
}
