using System.Text;

namespace BsBlazor.Helpers;

internal sealed class CssBuilder
{
    private readonly StringBuilder _buffer = new();
    private BsCssBuilder? _bsCssBuilder;
    
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
    public CssBuilder AddClass(string? value, bool? when) => when is true ? AddClass(value) : this;
    public CssBuilder AddBsClass(Func<BsCssBuilder, BsCssBuilder> bsClass)
    {
        _bsCssBuilder ??= new BsCssBuilder(value => AddClass(value));
        _bsCssBuilder = bsClass(_bsCssBuilder);
        return this;
    }
    public CssBuilder AddBsClass(Func<BsCssBuilder,BsCssBuilder> bsClass, bool when)
    {
        if (!when)
        {
            return this;
        }
        
        _bsCssBuilder ??= new BsCssBuilder(value => AddClass(value));
        _bsCssBuilder = bsClass(_bsCssBuilder);
        return this;
    }
    
    public string Build() => _buffer.ToString().Trim();

    public override string ToString() => Build();
}
