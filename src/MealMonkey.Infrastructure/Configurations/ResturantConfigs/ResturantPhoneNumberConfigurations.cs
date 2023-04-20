using MealMonkey.Domain.Entities.ResturantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.ResturantConfigs
{
    public class ResturantPhoneNumberConfigurations : IEntityTypeConfiguration<ResturantPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<ResturantPhoneNumber> builder)
        {
            // Properties
            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            // Relationships with
            // Resturant
            builder.HasOne(p => p.Resturant)
                .WithMany(r => r.ResturantPhoneNumbers)
                .HasForeignKey(p => p.ResturantId)
                .IsRequired();
        }
    }
}
