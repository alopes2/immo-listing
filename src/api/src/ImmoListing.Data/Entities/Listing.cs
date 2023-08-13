using System.Collections.ObjectModel;

namespace ImmoListing.Data.Entities;

public class Listing
{
    public const string TableName = "Listings";

    public long Id { get; set; }

    public string Name { get; set; }

    public Address Address { get; set; }

    public string Description { get; set; }

    public BuildingType BuildingType { get; set; }

    public double SurfaceAreaM2 { get; set; }

    public int RoomsCount { get; set; }

    public int BedroomsCount { get; set; }

    public long LatestPriceEur { get; set; }

    public string ContactPhoneNumber { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedDate { get; set; }

    public ICollection<Price> Prices { get; set; }

    public Listing()
    {
        Prices = new Collection<Price>();
    }
}
