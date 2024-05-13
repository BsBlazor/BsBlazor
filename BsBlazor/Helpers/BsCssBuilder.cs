using System.Text;

namespace BsBlazor;

public partial class BsCssBuilder
{
    private readonly StringBuilder? _buffer;
    private readonly Action<string>? _addCssClassAction;

    public BsCssBuilder(string value)
    {
        _buffer = new StringBuilder();
        _buffer.Append(value);
    }

    internal BsCssBuilder(Action<string?> addCssClassAction) => _addCssClassAction = addCssClassAction;

    private BsCssBuilder AddClass(string value)
    {
        
        if (_buffer is not null)
        {
            _buffer.Append(" " + value);
        }
        else
        {
            _addCssClassAction?.Invoke(value);
        }
        
        return this;
    }
    
    private string Build() => _buffer?.ToString().Trim() ?? string.Empty;
    public static implicit operator string(BsCssBuilder builder) => builder.Build();
    public override string ToString() => Build();
}