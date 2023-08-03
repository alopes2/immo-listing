namespace ImmoListing.Api.Models;

public record ListingResource(
        long Id,
        DateTime CreatedDate,
        DateTime UpdatedDate,
        string Name,
        PostalAddressResource PostalAddress,
        string Description,
        RealEstateListingBuildingTypeResource BuildingType,
        long LatestPriceEur,
        double SurfaceAreaM2,
        int RoomsCount,
        int BedroomsCount,
        string ContactPhoneNumber
);
