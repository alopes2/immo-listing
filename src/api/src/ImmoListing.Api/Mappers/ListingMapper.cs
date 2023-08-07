using ImmoListing.Api.Models;
using ImmoListing.Core.Models;

namespace ImmoListing.Api.Mappers;

public static class ListingMapper
{
    public static Listing ToListing(SaveListingResource listingResource, long listingId)
    {
        return new Listing
        {
            Id = listingId,
            Name = listingResource.Name,
            PostalAddress = ToPostalAddress(listingResource.PostalAddress),
            Description = listingResource.Description,
            BuildingType = Enum.Parse<RealEstateListingBuildingType>(listingResource.BuildingType.ToString()),
            LatestPriceEur = listingResource.LatestPriceEur,
            SurfaceAreaM2 = listingResource.SurfaceAreaM2,
            RoomsCount = listingResource.RoomsCount,
            BedroomsCount = listingResource.BedroomsCount,
            ContactPhoneNumber = listingResource.ContactPhoneNumber
        };
    }

    public static ListingResource ToListingResource(Listing listing)
    {
        var latestPrice = listing.Prices.FirstOrDefault();

        return new ListingResource
        (
            Id: listing.Id,
            Name: listing.Name,
            PostalAddress: ToPostalAddressResource(listing.PostalAddress),
            Description: listing.Description,
            BuildingType: Enum.Parse<RealEstateListingBuildingTypeResource>(listing.BuildingType.ToString()),
            LatestPriceEur: latestPrice?.PriceEur ?? 0,
            SurfaceAreaM2: listing.SurfaceAreaM2,
            RoomsCount: listing.RoomsCount,
            BedroomsCount: listing.BedroomsCount,
            ContactPhoneNumber: listing.ContactPhoneNumber,
            CreatedDate: listing.CreatedDate,
            UpdatedDate: listing.UpdatedDate
        );
    }

    public static IEnumerable<ListingResource> ToListingResources(IEnumerable<Listing> listings)
    {
        return listings.Select(ToListingResource);
    }

    internal static CreateListing ToCreateListing(SaveListingResource createListingResource)
    {
        return new CreateListing
        {
            Name = createListingResource.Name,
            PostalAddress = ToPostalAddress(createListingResource.PostalAddress),
            Description = createListingResource.Description,
            BuildingType = Enum.Parse<RealEstateListingBuildingType>(createListingResource.BuildingType.ToString()),
            LatestPriceEur = createListingResource.LatestPriceEur,
            SurfaceAreaM2 = createListingResource.SurfaceAreaM2,
            RoomsCount = createListingResource.RoomsCount,
            BedroomsCount = createListingResource.BedroomsCount,
            ContactPhoneNumber = createListingResource.ContactPhoneNumber
        };
    }

    private static PostalAddress ToPostalAddress(PostalAddressResource postalAddressResource)
    {
        return new PostalAddress
        {
            Street = postalAddressResource.StreetAddress,
            City = postalAddressResource.City,
            Country = postalAddressResource.Country,
            PostalCode = postalAddressResource.PostalCode
        };
    }

    private static PostalAddressResource ToPostalAddressResource(PostalAddress postalAddressResource)
    {
        return new PostalAddressResource
        (
            StreetAddress: postalAddressResource.Street,
            City: postalAddressResource.City,
            Country: postalAddressResource.Country,
            PostalCode: postalAddressResource.PostalCode
        );
    }
}
