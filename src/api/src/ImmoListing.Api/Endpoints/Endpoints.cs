using ImmoListing.Api.Endpoints.Listings;

namespace ImmoListing.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
            app.MapGroup(ListingsMapGroup.Prefix)
                .MapListings()
                .WithTags("Listings");
    }
}
