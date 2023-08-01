namespace ImmoListing.Api.Models;

public record ListingResource(
        long Id,
        DateTime CreatedDate,
        DateTime UpdatedDate,
        string Name,
        PostalAddress PostalAddress,
        string Description,
        RealEstateListingBuildingType BuildingType,
        double LatestPriceEur,
        double SurfaceAreaM2,
        int RoomsCount,
        int BedroomsCount,
        string ContactPhoneNumber
);
