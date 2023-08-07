namespace ImmoListing.Data.Entities;

public class Price
{
    public const string TableName = "Prices";
    
    public long Id { get; set; }

    public long Value { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public long ListingId { get; set; }

    public Listing Listing { get; set; }
}
