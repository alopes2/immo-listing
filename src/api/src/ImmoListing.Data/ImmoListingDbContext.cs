using System.Reflection;
using ImmoListing.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImmoListing.Data;

public class ImmoListingDbContext : DbContext
{
    public const string ConnectionString = "ImmoListing";
    public DbSet<Listing> Listings { get; set; }
    
    public DbSet<Price> Prices { get; set; }

    public ImmoListingDbContext(DbContextOptions<ImmoListingDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
