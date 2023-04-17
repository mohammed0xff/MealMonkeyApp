using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Properities
            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Details)
                .IsRequired()
                .HasMaxLength(200);

            // Relationships
            // City
            builder.HasOne<City>(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .IsRequired();

            // User
            builder.HasOne<User>(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId);

            // Resturant
            builder.HasOne<Resturant>(a => a.Resturant)
                .WithMany(r => r.Addresses)
                .HasForeignKey(a => a.ResturantId);
        }
    }
}
