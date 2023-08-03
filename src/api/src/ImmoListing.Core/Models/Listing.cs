namespace ImmoListing.Core.Models;

public class Listing
{
    public long Id { get; set; }

    public string Name { get; set; }

    public PostalAddress PostalAddress { get; set; }

    public string Description { get; set; }

    public RealEstateListingBuildingType BuildingType { get; set; }

    public long LatestPriceEur { get; set; }

    public double SurfaceAreaM2 { get; set; }

    public int RoomsCount { get; set; }

    public int BedroomsCount { get; set; }

    public string ContactPhoneNumber { get; set; }

    public DateTime CreatedDate  { get; set; }
    
    public DateTime UpdatedDate  { get; set; }
}
