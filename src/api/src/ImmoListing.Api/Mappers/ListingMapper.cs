using ImmoListing.Api.Models;
using ImmoListing.Core.Models;

namespace ImmoListing.Api.Mappers;

public static class ListingMapper
{
    public static Listing ToListing(SaveListingResource listingResource, long listingId = 0)
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
        return new ListingResource
        (
            Id: listing.Id,
            Name: listing.Name,
            PostalAddress: ToPostalAddressResource(listing.PostalAddress),
            Description: listing.Description,
            BuildingType: Enum.Parse<RealEstateListingBuildingTypeResource>(listing.BuildingType.ToString()),
            LatestPriceEur: listing.LatestPriceEur,
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

    private static PostalAddress ToPostalAddress(PostalAddressResource postalAddressResource)
    {
        return new PostalAddress
        {
            StreetAddress = postalAddressResource.StreetAddress,
            City = postalAddressResource.City,
            Country = postalAddressResource.Country,
            PostalCode = postalAddressResource.PostalCode
        };
    }

    private static PostalAddressResource ToPostalAddressResource(PostalAddress postalAddressResource)
    {
        return new PostalAddressResource
        (
            StreetAddress: postalAddressResource.StreetAddress,
            City: postalAddressResource.City,
            Country: postalAddressResource.Country,
            PostalCode: postalAddressResource.PostalCode
        );
    }
}
