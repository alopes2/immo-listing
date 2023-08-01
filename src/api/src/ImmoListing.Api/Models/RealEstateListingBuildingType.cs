using System.Text.Json.Serialization;

namespace ImmoListing.Api.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RealEstateListingBuildingType
{
    STUDIO = 0,
    APARTMENT = 1,
    HOUSE = 2,
}
