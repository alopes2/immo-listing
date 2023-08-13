using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImmoListing.Data.Entities.Configurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(l => l.RoomsCount)
            .IsRequired();

        builder.Property(l => l.BedroomsCount)
            .IsRequired();

        builder.Property(l => l.BuildingType)
            .IsRequired();

        builder.Property(l => l.ContactPhoneNumber)
            .IsRequired();

        builder.Property(l => l.Description)
            .HasMaxLength(5000)
            .IsRequired();

        builder.Property(l => l.SurfaceAreaM2)
            .IsRequired();

        builder.Property(l => l.LatestPriceEur)
            .IsRequired();

        builder.Property(l => l.CreatedDate)
            .IsRequired();

        builder.Property(l => l.UpdatedDate)
            .IsRequired();

        builder.OwnsOne(
            l => l.Address,
            address =>
            {
                address.Property(a => a.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName(nameof(Address.City));

                address.Property(a => a.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName(nameof(Address.Country));

                address.Property(a => a.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName(nameof(Address.PostalCode));

                address.Property(a => a.Street)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasColumnName(nameof(Address.Street));
            });

        builder.HasMany(l => l.Prices)
            .WithOne(p => p.Listing)
            .HasForeignKey(p => p.ListingId);

        builder.ToTable(Listing.TableName);
    }
}
