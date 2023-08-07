using ImmoListing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImmoListing.Data.Entities.Configurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
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
            .IsRequired();
        
        builder.Property(l => l.SurfaceAreaM2)
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
                    .HasColumnName(nameof(Address.City));

                address.Property(a => a.Country)
                    .IsRequired()
                    .HasColumnName(nameof(Address.Country));

                address.Property(a => a.PostalCode)
                    .IsRequired()
                    .HasColumnName(nameof(Address.PostalCode));

                address.Property(a => a.Street)
                    .IsRequired()
                    .HasColumnName(nameof(Address.Street));
            });

        builder.HasMany(l => l.Prices)
            .WithOne(p => p.Listing)
            .HasForeignKey(p => p.ListingId);

        builder.ToTable(Listing.TableName);
    }
}
