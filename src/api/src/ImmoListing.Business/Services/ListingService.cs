using ImmoListing.Core.Services;
using ImmoListing.Core.Models;
using Entities = ImmoListing.Data.Entities;
using OneOf;
using OneOf.Types;
using ImmoListing.Data;
using Microsoft.EntityFrameworkCore;
using ImmoListing.Business.Mappers;

namespace ImmoListing.Business.Services;

public class ListingService : IListingsService
{
    private readonly ImmoListingDbContext _dbContext;

    public ListingService(ImmoListingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OneOf<Listing, Error>> CreateListing(CreateListing newListing)
    {
        var entity = ListingMapper.ToCreateEntity(newListing);

        await _dbContext.Listings.AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        var listingModel = ListingMapper.ToCoreModel(entity);

        return listingModel;
    }

    public async Task<OneOf<Listing, NotFound, Error>> GetListingById(long listingId)
    {
        var listing = await _dbContext.Listings
            .Include(l => l.Prices.OrderByDescending(p => p.CreatedDate))
            .SingleOrDefaultAsync(l => l.Id == listingId);

        if (listing is null)
        {
            return new NotFound();
        }

        var listingModel = ListingMapper.ToCoreModel(listing);

        return listingModel;
    }

    public async Task<OneOf<IEnumerable<Listing>, Error>> GetListings()
    {
        var listings = await _dbContext.Listings
            .Include(l => l.Prices.OrderByDescending(p => p.CreatedDate))
            .ToListAsync();

        var listingModels = ListingMapper.ToCoreModel(listings);

        return OneOf<IEnumerable<Listing>, Error>.FromT0(listingModels);
    }

    public async Task<OneOf<Success, NotFound, Error>> UpdateListing(Listing listingToUpdate)
    {
        var foundListing = await _dbContext.Listings
            .Include(l => l.Prices.OrderByDescending(p => p.CreatedDate))
            .SingleOrDefaultAsync(l => l.Id == listingToUpdate.Id);

        if (foundListing is null)
        {
            return new NotFound();
        }
        
        var latestPrice = foundListing.Prices.FirstOrDefault();

        if (listingToUpdate.LatestPriceEur != latestPrice?.Value)
        {
            foundListing.Prices.Add(new Entities.Price { 
                Value = listingToUpdate.LatestPriceEur
                });
        }

        foundListing.Name = listingToUpdate.Name;
        foundListing.BedroomsCount = listingToUpdate.BedroomsCount;
        foundListing.RoomsCount = listingToUpdate.RoomsCount;
        foundListing.BuildingType = Enum.Parse<Entities.BuildingType>(listingToUpdate.BuildingType.ToString());
        foundListing.ContactPhoneNumber = listingToUpdate.ContactPhoneNumber;
        foundListing.Description = listingToUpdate.Description;
        foundListing.Address = ListingMapper.ToEntityAddress(listingToUpdate.PostalAddress);
        foundListing.RoomsCount = listingToUpdate.RoomsCount;
        foundListing.SurfaceAreaM2 = listingToUpdate.SurfaceAreaM2;

        foundListing.UpdatedDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new Success();
    }

    public async Task<OneOf<Success, NotFound, Error>> DeleteListingById(long listingId)
    {
        var foundListing = await _dbContext.Listings.FindAsync(listingId);

        if (foundListing is null)
        {
            return new NotFound();
        }

        _dbContext.Listings.Remove(foundListing);

        await _dbContext.SaveChangesAsync();

        return new Success();
    }
}
