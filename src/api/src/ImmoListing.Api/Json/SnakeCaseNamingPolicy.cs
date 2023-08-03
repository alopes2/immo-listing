using System.Text.Json;
using ImmoListing.Core.Extensions;

namespace ImmoListing.Api.Json;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }
 
        return name.ToSnakeCase();
    }
}