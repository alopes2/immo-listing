namespace ImmoListing.Business.Mappers;

using ImmoListing.Data.Entities;
using CoreModels = Core.Models;

public static class ListingMapper
{
    public static CoreModels.Listing ToCoreModel(Listing listing)
    {
        var prices = listing.Prices.Select(ToCorePrice).ToList();

        return new CoreModels.Listing
        {
            Id = listing.Id,
            BedroomsCount = listing.BedroomsCount,
            BuildingType = Enum.Parse<CoreModels.RealEstateListingBuildingType>(listing.BuildingType.ToString()),
            ContactPhoneNumber = listing.ContactPhoneNumber,
            Description = listing.Description,
            Prices = prices,
            LatestPriceEur = listing.LatestPriceEur,
            Name = listing.Name,
            PostalAddress = ToCorePostalAddress(listing.Address),
            RoomsCount = listing.RoomsCount,
            SurfaceAreaM2 = listing.SurfaceAreaM2,
            CreatedDate = listing.CreatedDate,
            UpdatedDate = listing.UpdatedDate
        };
    }
    public static IEnumerable<CoreModels.Listing> ToCoreModel(ICollection<Listing> entities)
    {
        var listings = entities
            .Select(l => ToCoreModel(l));

        return listings;
    }

    public static Listing ToCreateEntity(CoreModels.CreateListing listing)
    {
        var entity = new Listing
        {
            BedroomsCount = listing.BedroomsCount,
            BuildingType = Enum.Parse<BuildingType>(listing.BuildingType.ToString()),
            ContactPhoneNumber = listing.ContactPhoneNumber,
            Description = listing.Description,
            Name = listing.Name,
            Address = ToEntityAddress(listing.PostalAddress),
            RoomsCount = listing.RoomsCount,
            SurfaceAreaM2 = listing.SurfaceAreaM2,
            LatestPriceEur = listing.LatestPriceEur,
            UpdatedDate = DateTime.UtcNow
        };

        entity.Prices.Add(
            new Price
            {
                Value = listing.LatestPriceEur
            });

        return entity;
    }

    private static CoreModels.Price ToCorePrice(Price price)
    {
        return new CoreModels.Price
        {
            PriceEur = price.Value,
            CreatedDate = price.CreatedDate
        };
    }

    private static CoreModels.PostalAddress ToCorePostalAddress(Address address)
    {
        return new CoreModels.PostalAddress
        {
            City = address.City,
            Country = address.Country,
            PostalCode = address.PostalCode,
            Street = address.Street
        };
    }

    public static Address ToEntityAddress(CoreModels.PostalAddress address)
    {
        return new Address
        {
            City = address.City,
            Country = address.Country,
            PostalCode = address.PostalCode,
            Street = address.Street
        };
    }
}
