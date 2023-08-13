using System.Reflection;
using System.Text.Json.Serialization;

namespace ImmoListing.Api.Models;

public class GetListingsQueryParams
{
    public int Page { get; set; } = 0;

    public int Size { get; set; } = 10;

    public string? Name { get; set; }

    public RealEstateListingBuildingTypeResource? BuildingType { get; set; }

    public long? MinPrice { get; set; }

    public long? MaxPrice { get; set; }


    public static ValueTask<GetListingsQueryParams?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        var name = context.Request.Query["name"];

        var result = new GetListingsQueryParams
        {
            Name = name
        };

        if (Enum.TryParse<RealEstateListingBuildingTypeResource>(context.Request.Query["building_type"].ToString().ToUpper(), out var buildingType))
        {
            result.BuildingType = buildingType;
        }

        if (long.TryParse(context.Request.Query["min_price"], out var minPrice))
        {
            result.MinPrice = minPrice;
        }

        if (long.TryParse(context.Request.Query["max_price"], out var maxPrice))
        {
            result.MaxPrice = maxPrice;
        }

        if (int.TryParse(context.Request.Query["page"], out var page))
        {
            result.Page = page;
        }

        if (int.TryParse(context.Request.Query["size"], out var size))
        {
            result.Size = size;
        }

        return ValueTask.FromResult<GetListingsQueryParams?>(result);
    }
}
