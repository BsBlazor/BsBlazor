namespace BsBlazor;
// NOTE: think about this helper...
// Maybe bootstrap developers would prefer to use bootstrap classnames directly instead
public static class Bs
{
    public static BsCssBuilder Css => new(string.Empty);
    public static BsCssBuilder Default(string value) => new(value);
}