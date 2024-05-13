namespace BsBlazor;

public static class Bs
{
    public static BsCssBuilder Css => new(string.Empty);
    public static BsCssBuilder Default(string value) => new(value);
}