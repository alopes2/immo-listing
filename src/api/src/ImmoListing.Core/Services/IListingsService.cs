using ImmoListing.Core.Models;
using OneOf;
using OneOf.Types;

namespace ImmoListing.Core.Services;

public interface IListingsService
{
    Task<OneOf<Listing, Error>> CreateListing(Listing newListing);

    Task<OneOf<Listing, NotFound, Error>> GetListingById(long listingId);

    Task<OneOf<IEnumerable<Listing>, Error>> GetListings();
    
    Task<OneOf<Listing, NotFound, Error>> UpdateListing(Listing listingToUpdate);
    
    Task<OneOf<Success, NotFound, Error>> DeleteListingById(long listingId);
    
    Task<OneOf<IEnumerable<Price>, NotFound, Error>> GetListingPrices(long listingId);
}
