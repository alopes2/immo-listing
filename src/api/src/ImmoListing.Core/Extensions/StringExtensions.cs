using System.Text;

namespace ImmoListing.Core.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string value)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < value.Length; i++)
        {
            if (char.IsUpper(value[i]))
            {
                if (i > 0 && value[i - 1] != '_')
                {
                    builder.Append('_');
                }

                builder.Append(char.ToLower(value[i]));
            }
            else
            {
                builder.Append(value[i]);
            }
        }

        return builder.ToString();
    }
}
