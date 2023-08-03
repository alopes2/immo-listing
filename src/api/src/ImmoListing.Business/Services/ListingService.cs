using ImmoListing.Core.Services;
using ImmoListing.Core.Models;
using OneOf;
using OneOf.Types;

namespace ImmoListing.Business.Services;

public class ListingService : IListingsService
{
    public async Task<OneOf<Listing, Error>> CreateListing(Listing newListing)
    {
        await Task.Delay(1);
        
        return new Error();
    }

    public async Task<OneOf<Listing, NotFound, Error>> GetListingById(long listingId)
    {
        await Task.Delay(1);

        return new NotFound();
    }

    public async Task<OneOf<IEnumerable<Listing>, Error>> GetListings()
    {
        await Task.Delay(1);

        return new Error();
    }

    public async Task<OneOf<Listing, NotFound, Error>> UpdateListing(Listing listingToUpdate)
    {
        await Task.Delay(1);

        return new NotFound();
    }

    public async Task<OneOf<Success, NotFound, Error>> DeleteListingById(long listingId)
    {
        await Task.Delay(1);

        return new NotFound();
    }

    public async Task<OneOf<IEnumerable<Price>, NotFound, Error>> GetListingPrices(long listingId)
    {
        await Task.Delay(1);

        return new NotFound();
    }
}
