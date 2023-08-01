using ImmoListing.Api.Endpoints.MapGroups;

namespace ImmoListing.Api.Endpoints;

public static class Listings
{
    public static void MapListingsEndpoints(this WebApplication app)
    {
            app.MapGroup(ListingsMapGroup.Prefix)
                .MapListings()
                .WithTags("Listings");
    }
}
