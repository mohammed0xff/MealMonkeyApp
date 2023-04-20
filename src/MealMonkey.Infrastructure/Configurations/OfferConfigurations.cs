using MealMonkey.Domain.Entities.MealEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class OfferConfigurations : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            // Properties
            builder.Property(o => o.Discount)
                .IsRequired();
            builder.Property(o => o.Title)
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(o => o.Details)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(o => o.StartDate)
                .IsRequired();
            builder.Property(o => o.EndDate)
                .IsRequired();
        }
    }
}
