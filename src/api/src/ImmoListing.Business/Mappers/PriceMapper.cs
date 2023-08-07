namespace ImmoListing.Business.Mappers;

using ImmoListing.Core.Models;
using Entites = Data.Entities;

public static class PriceMapper
{
    public static Price ToCoreModel(Entites.Price price)
    {
        return new Price
        {
            PriceEur = price.Value,
            CreatedDate = price.CreatedDate
        };
    }

    public static IEnumerable<Price> ToCoreModel(ICollection<Entites.Price> price)
    {
        return price.Select(ToCoreModel);
    }
}
