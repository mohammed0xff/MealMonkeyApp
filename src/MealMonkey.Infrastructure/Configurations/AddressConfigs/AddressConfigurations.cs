using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.ResturantEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.AddressConfigs
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Properities
            builder.HasKey(x => x.Id);

            builder.ToTable(nameof(ApplicationDbContext.Addresses));

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
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .IsRequired();

            // User
            builder.HasOne<User>()
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .IsRequired(false);

            // Resturant
            builder.HasOne<Resturant>()
                .WithMany(r => r.Addresses)
                .HasForeignKey(a => a.ResturantId)
                .IsRequired(false);
        }
    }
}
