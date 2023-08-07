using ImmoListing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImmoListing.Data.Entities.Configurations;

public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Value)
            .IsRequired();

        builder.HasOne(p => p.Listing)
            .WithMany(l => l.Prices)
            .HasForeignKey(p => p .ListingId);

        builder.ToTable(Price.TableName);
    }
}
