using FluentValidation;
using ImmoListing.Api.Extensions;
using ImmoListing.Api.Mappers;
using ImmoListing.Api.Models;
using ImmoListing.Core.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace ImmoListing.Api.Endpoints.Listings;

public static class Handlers
{
    public static async Task<Results<Ok<ListingResource>, StatusCodeHttpResult, BadRequest<IEnumerable<ValidationError>>>> CreateListingAsync(
        [FromBody] SaveListingResource createListingResource,
        IListingsService listingsService,
        IValidator<SaveListingResource> validator)
    {
        var validationResult = await validator.ValidateAsync(createListingResource);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest(validationResult.GetValidationErrors());
        }
        var listing = ListingMapper.ToCreateListing(createListingResource);

        var createListingResult = await listingsService.CreateListing(listing);

        return createListingResult.Match<Results<Ok<ListingResource>, StatusCodeHttpResult, BadRequest<IEnumerable<ValidationError>>>>(
            newListing => TypedResults.Ok(ListingMapper.ToListingResource(newListing)),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok<IEnumerable<ListingResource>>, StatusCodeHttpResult>> GetListingsAsync(
        IListingsService listingsService)
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

    public static async Task<Results<Ok<ListingResource>, BadRequest<ValidationError>, NotFound, StatusCodeHttpResult>> GetListingByIdAsync(
        [FromRoute] long listingId,
        IListingsService listingsService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest(new ValidationError(nameof(listingId), new string[]{"listingId not provided"}));
        }

        var getListingResult = await listingsService.GetListingById(listingId);

        return getListingResult.Match<Results<Ok<ListingResource>, BadRequest<ValidationError>, NotFound, StatusCodeHttpResult>>(
            newListing => TypedResults.Ok(ListingMapper.ToListingResource(newListing)),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok, BadRequest<IEnumerable<ValidationError>>, NotFound, StatusCodeHttpResult>> UpdateListingByIdAsync(
        [FromRoute] long listingId,
        [FromBody] SaveListingResource saveListingResource,
        IListingsService listingsService,
        IValidator<SaveListingResource> validator)
    {
        var validationResult = await validator.ValidateAsync(saveListingResource);
        if (listingId == 0 || !validationResult.IsValid)
        {
            return TypedResults.BadRequest(validationResult.GetValidationErrors());
        }

        var listing = ListingMapper.ToListing(saveListingResource, listingId);

        var updateListingResult = await listingsService.UpdateListing(listing);

        return updateListingResult.Match<Results<Ok, BadRequest<IEnumerable<ValidationError>>, NotFound, StatusCodeHttpResult>>(
            success => TypedResults.Ok(),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<Ok<IEnumerable<PriceResource>>, BadRequest<ValidationError>, NotFound, StatusCodeHttpResult>> GetListingPricesAsync(
        [FromRoute] long listingId,
        IPriceService priceService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest(new ValidationError(nameof(listingId), new string[]{"listingId not provided"}));
        }

        var getListingPricesResult = await priceService.GetListingPrices(listingId);

        return getListingPricesResult.Match<Results<Ok<IEnumerable<PriceResource>>, BadRequest<ValidationError>, NotFound, StatusCodeHttpResult>>(
            listingPrices => TypedResults.Ok(PriceMapper.ToPriceResources(listingPrices)),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }

    public static async Task<Results<NoContent, BadRequest<ValidationError>, NotFound, StatusCodeHttpResult>> DeleteListingByIdAsync(
        [FromRoute] int listingId,
        IListingsService listingsService)
    {
        if (listingId == 0)
        {
            return TypedResults.BadRequest(new ValidationError(nameof(listingId), new string[]{"listingId not provided"}));
        }

        var deleteListingResult = await listingsService.DeleteListingById(listingId);

        return deleteListingResult.Match<Results<NoContent, BadRequest<ValidationError>, NotFound, StatusCodeHttpResult>>(
            success => TypedResults.NoContent(),
            notFound => TypedResults.NotFound(),
            error => TypedResults.StatusCode(StatusCodes.Status500InternalServerError)
        );
    }
}
