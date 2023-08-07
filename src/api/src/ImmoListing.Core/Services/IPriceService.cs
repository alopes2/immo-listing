using ImmoListing.Core.Models;
using OneOf;
using OneOf.Types;

namespace ImmoListing.Core.Services;

public interface IPriceService
{
    Task<OneOf<IEnumerable<Price>, NotFound, Error>> GetListingPrices(long listingId);
}
