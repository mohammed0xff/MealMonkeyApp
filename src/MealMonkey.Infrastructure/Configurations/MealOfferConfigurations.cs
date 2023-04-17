using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace MealMonkey.Infrastructure.Configurations
{
    public class MealOfferConfigurations : IEntityTypeConfiguration<MealOffer>
    {
        public void Configure(EntityTypeBuilder<MealOffer> builder)
        {
            // Primary Key
            builder.HasKey(mo => new { mo.MealId, mo.OfferId });

            // Relationship with
            // Offer
            builder.HasOne<Meal>(mf => mf.Meal)
                .WithMany(m => m.MealOffers)
                .HasForeignKey(mo => mo.MealId)
                .IsRequired();

            // Meal
            builder.HasOne<Offer>(mf => mf.Offer)
                .WithMany(o => o.MealOffers)
                .HasForeignKey(mo => mo.OfferId)
                .IsRequired();
        }
    }
}
