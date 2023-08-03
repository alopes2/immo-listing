using ImmoListing.Api.Mappers;
using ImmoListing.Api.Models;
using ImmoListing.Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace ImmoListing.Api.Endpoints.Listings;

public static class Handlers
{
    public static async Task<Results<Ok<ListingResource>, StatusCodeHttpResult, BadRequest>> CreateListingAsync([FromBody] SaveListingResource createListingResource, IListingsService listingsService)
    {
        var listing = ListingMapper.ToListing(createListingResource);

        var createListingResult = await listingsService.CreateListing(listing);

        return createListingResult.Match<Results<Ok<ListingResource>, StatusCodeHttpResult, BadRequest>>(
            newListing => TypedResults.Ok(ListingMapper.ToListingResource(newListing)),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok<IEnumerable<ListingResource>>, StatusCodeHttpResult>> GetListingsAsync(IListingsService listingsService)
    {
        var getListingsResult = await listingsService.GetListings();

        return getListingsResult.Match<Results<Ok<IEnumerable<ListingResource>>, StatusCodeHttpResult>>(
            listings =>
            {
                var listingsResources = ListingMapper.ToListingResources(listings);

                return TypedResults.Ok(listingsResources);
            },
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok<ListingResource>, BadRequest, NotFound, StatusCodeHttpResult>> GetListingByIdAsync([FromRoute] long listingId, IListingsService listingsService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest();
        }

        var getListingResult = await listingsService.GetListingById(listingId);

        return getListingResult.Match<Results<Ok<ListingResource>, BadRequest, NotFound, StatusCodeHttpResult>>(
            newListing => TypedResults.Ok(ListingMapper.ToListingResource(newListing)),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok<ListingResource>, BadRequest, NotFound, StatusCodeHttpResult>> UpdateListingByIdAsync(
        [FromRoute] long listingId,
        [FromBody] SaveListingResource saveListingResource,
        IListingsService listingsService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest();
        }

        var listing = ListingMapper.ToListing(saveListingResource, listingId);

        var updateListingResult = await listingsService.UpdateListing(listing);

        return updateListingResult.Match<Results<Ok<ListingResource>, BadRequest, NotFound, StatusCodeHttpResult>>(
            updatedListing => TypedResults.Ok(ListingMapper.ToListingResource(updatedListing)),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok<IEnumerable<PriceResource>>, BadRequest, NotFound, StatusCodeHttpResult>> GetListingPricesAsync([FromRoute] long listingId, IListingsService listingsService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest();
        }

        var getListingPricesResult = await listingsService.GetListingPrices(listingId);

        return getListingPricesResult.Match<Results<Ok<IEnumerable<PriceResource>>, BadRequest, NotFound, StatusCodeHttpResult>>(
            listingPrices => TypedResults.Ok(PriceMapper.ToPriceResources(listingPrices)),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<NoContent, BadRequest, NotFound, StatusCodeHttpResult>> DeleteListingByIdAsync([FromRoute] int listingId, IListingsService listingsService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest();
        }

        var deleteListingResult = await listingsService.DeleteListingById(listingId);

        return deleteListingResult.Match<Results<NoContent, BadRequest, NotFound, StatusCodeHttpResult>>(
            success => TypedResults.NoContent(),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }
}
