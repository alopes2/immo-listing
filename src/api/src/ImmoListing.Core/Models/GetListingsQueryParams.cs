namespace ImmoListing.Core.Models;

public class GetListingsQueryParams
{
    public int Page { get; set; } = 0;

    public int Size { get; set; } = 10;

    public string? Name { get; set; }

    public RealEstateListingBuildingType? BuildingType { get; set; }

    public long? MinPrice { get; set; }

    public long? MaxPrice { get; set; }
}
