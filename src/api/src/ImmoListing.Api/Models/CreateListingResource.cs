namespace ImmoListing.Api.Models;

public record CreateListingResource(
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
