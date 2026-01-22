using System.Text;

namespace BsBlazor.Helpers;
internal sealed class InternalCssBuilder 
{
    private readonly StringBuilder _buffer = new();
    private BsCssBuilder? _bsCssBuilder;
    
    public static InternalCssBuilder Default(string value) => new(value);
    public static InternalCssBuilder Empty() => new(string.Empty);
    private InternalCssBuilder(string value) => _buffer.Append(value);
    
    private InternalCssBuilder AddValue(string? value)
    {
        _buffer.Append(value);
        return this;
    }
    
    public InternalCssBuilder AddClass(string? value) => AddValue(" " + value);
    public InternalCssBuilder AddClass(string? value, bool when) => when ? AddClass(value) : this;
    public InternalCssBuilder AddClass(string? value, bool? when) => when is true ? AddClass(value) : this;
    public InternalCssBuilder AddBsClass(Func<BsCssBuilder, BsCssBuilder> bsClass)
    {
        _bsCssBuilder ??= new BsCssBuilder(value => AddClass(value));
        _bsCssBuilder = bsClass(_bsCssBuilder);
        return this;
    }
    public InternalCssBuilder AddBsClass(Func<BsCssBuilder,BsCssBuilder> bsClass, bool when)
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
    public static implicit operator string(InternalCssBuilder builder) => builder.Build();
    public override string ToString() => Build();
}
