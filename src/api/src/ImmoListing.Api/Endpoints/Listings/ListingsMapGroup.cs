using System.Net.Mime;
using ImmoListing.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ImmoListing.Api.Endpoints.Listings;

public static class ListingsMapGroup
{
    public const string Prefix = "/listings";

    public static RouteGroupBuilder MapListings(this RouteGroupBuilder router)
    {
        router.MapPost(pattern: "/", Handlers.CreateListingAsync)
            .Accepts<SaveListingResource>(MediaTypeNames.Application.Json)
            .Produces<ListingResource>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        router.MapGet("/", Handlers.GetListingsAsync)
            .Produces<IEnumerable<ListingResource>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

        router.MapGet("/{listingId}", Handlers.GetListingByIdAsync)
            .Produces<ListingResource>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        router.MapGet("/{listingId}/prices", Handlers.GetListingPricesAsync)
            .Produces<IEnumerable<PriceResource>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        router.MapPut("/{listingId}", Handlers.UpdateListingByIdAsync)
            .Produces<ListingResource>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        router.MapDelete("/{listingId}", Handlers.DeleteListingByIdAsync)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

        return router;
    }
}
