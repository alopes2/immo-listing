
using System.Text;
using System.Text.Json;
using ImmoListing.Api.Extensions;

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