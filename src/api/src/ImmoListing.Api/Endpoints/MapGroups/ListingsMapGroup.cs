using System.Net.Mime;
using ImmoListing.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ImmoListing.Api.Endpoints.MapGroups;

public static class ListingsMapGroup
{
    public const string Prefix = "/listings";

    public static RouteGroupBuilder MapListings(this RouteGroupBuilder router)
    {
        router.MapPost(pattern: "/", () =>
        {
            return Results.Ok();
        })
        .Accepts<CreateListingResource>(MediaTypeNames.Application.Json)
        .Produces<ListingResource>(StatusCodes.Status201Created, MediaTypeNames.Application.Json);

        router.MapGet("/", () =>
        {
            return TypedResults.Ok();
        })
        .Produces<IEnumerable<ListingResource>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound);

        router.MapGet("/{id}", Results<Ok<ListingResource>, BadRequest> ([FromRoute] int id) =>
        {

            if (id == 0)
            {
                return TypedResults.BadRequest();
            }

            var result = new ListingResource(
                default,
                default,
                default,
                RealEstateListingBuildingType.STUDIO.ToString(),
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default);

            return TypedResults.Ok(result);
        })
        .Produces<ListingResource>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound);

        router.MapPut("/{id}", () =>
        {
            return Results.Ok();
        })
        .Produces<ListingResource>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound);

        router.MapDelete("/{id}", () =>
        {
            return Results.Ok();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return router;
    }
}
