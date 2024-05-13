using System.Buffers;

namespace BsBlazor.Extensions;

internal static class EnumExtensions
{
    // https://stackoverflow.com/a/70943830/1851755
    public static string ToKebabCase<T>(this T value) where T: Enum
    {
        var text = value.ToString();
        var buffer = ArrayPool<char>.Shared.Rent(text.Length + 10); // define max size of the internal buffer, 10 = max 10 segments

        try
        {
            var resultLength = 0;
            for (var i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && i > 0)
                {
                    buffer[resultLength++] = '-';
                }
                buffer[resultLength++] = char.ToLowerInvariant(text[i]);
            }

            return new string(buffer.AsSpan().Slice(0, resultLength));

        }
        finally
        {
            ArrayPool<char>.Shared.Return(buffer);
        }
    }
}