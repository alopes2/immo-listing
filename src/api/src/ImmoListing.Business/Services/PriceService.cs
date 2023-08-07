using ImmoListing.Business.Mappers;
using ImmoListing.Core.Models;
using ImmoListing.Core.Services;
using ImmoListing.Data;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;

namespace ImmoListing.Business.Services;

public class PriceService : IPriceService
{
    private readonly ImmoListingDbContext _dbContext;

    public PriceService(ImmoListingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OneOf<IEnumerable<Price>, NotFound, Error>> GetListingPrices(long listingId)
    {
        var prices = await _dbContext.Prices
            .Where(p => p.ListingId == listingId)
            .ToListAsync();

        if (prices == null)
        {
            return new NotFound();
        }
        
        var priceModels = PriceMapper.ToCoreModel(prices);

        return OneOf<IEnumerable<Price>, NotFound, Error>.FromT0(priceModels);
    }
}
