using MealMonkey.Domain.Entities.MealEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
namespace MealMonkey.Infrastructure.Configurations
{
    public class MealOfferConfigurations : IEntityTypeConfiguration<MealsOffers>
    {
        public void Configure(EntityTypeBuilder<MealsOffers> builder)
        {
            // Primary Key
            builder.HasKey(mo => new { mo.MealId, mo.OfferId });

            // Relationship with
            // Offer
            builder.HasOne(mf => mf.Meal)
                .WithMany(m => m.MealsOffers)
                .HasForeignKey(mo => mo.MealId)
                .IsRequired();

            // Meal
            builder.HasOne(mf => mf.Offer)
                .WithMany(o => o.MealsOffers)
                .HasForeignKey(mo => mo.OfferId)
                .IsRequired();
        }
    }
}
