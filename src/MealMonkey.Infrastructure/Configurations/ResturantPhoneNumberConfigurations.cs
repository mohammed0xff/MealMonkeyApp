using MealMonkey.Domain.Entities.ResturantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class ResturantPhoneNumberConfigurations : IEntityTypeConfiguration<ResturantPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<ResturantPhoneNumber> builder)
        {
            // Properties
            builder.Property(rpm => rpm.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            // Relationships with
            // Resturant
            builder.HasOne<Resturant>(rpm => rpm.Resturant)
                .WithMany(r => r.ResturantPhoneNumbers)
                .HasForeignKey(rpm => rpm.ResturantId)
                .IsRequired();
        }
    }
}
