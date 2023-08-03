using ImmoListing.Api.Models;
using ImmoListing.Core.Models;

namespace ImmoListing.Api.Mappers;

public static class PriceMapper
{
    public static PriceResource ToPriceResource(Price price)
    {
        return new PriceResource(
            price.PriceEur,
            price.CreatedDate
        );
    }
    public static IEnumerable<PriceResource> ToPriceResources(IEnumerable<Price> prices)
    {
        return prices.Select(ToPriceResource);
    }
}
