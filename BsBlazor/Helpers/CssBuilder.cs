using System.Text;

namespace BsBlazor.Helpers;

internal readonly struct CssBuilder
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
    
    public CssBuilder AddClass(string? value) => AddValue(" " + value);
    public CssBuilder AddClass(string? value, bool when) => when ? AddClass(value) : this;
    public CssBuilder AddClass(string? value, bool? when) => when == true ? AddClass(value) : this;
    
    public string Build() => _buffer.ToString().Trim();

    public override string ToString() => Build();
}
