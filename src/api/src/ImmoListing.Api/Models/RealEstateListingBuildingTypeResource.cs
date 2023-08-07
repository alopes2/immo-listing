using System.Text.Json.Serialization;

namespace ImmoListing.Api.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RealEstateListingBuildingTypeResource
{
    STUDIO = 1,
    APARTMENT,
    HOUSE,
}
