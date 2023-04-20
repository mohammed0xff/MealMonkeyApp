using MealMonkey.Domain.Entities.MealEntities;
using MealMonkey.Domain.Entities.ResturantEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.MealConfigs
{
    public class MealConfigurations : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            //Properties
            builder.Property(m => m.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(m => m.Price).IsRequired();
            builder.Property(m => m.ThumpUrl).IsRequired();
            builder.Property(m => m.PhotoUrl).IsRequired();
            builder.Property(m => m.AverageRating).IsRequired();


            // Relationships
            // Category
            builder.HasOne(m => m.Category)
                .WithMany(c => c.Meals)
                .HasForeignKey(m => m.CategoryId)
                .IsRequired();

            // Resturant
            builder.HasOne(m => m.Resturant)
                .WithMany(r => r.Meals)
                .HasForeignKey(m => m.ResturantId)
                .IsRequired();

            // MealType
            builder.HasOne(m => m.MealType)
                .WithMany(mt => mt.Meals)
                .HasForeignKey(m => m.MealTypeId)
                .IsRequired();

            // Serving
            builder.HasOne(m => m.Serving)
                .WithMany()
                .HasForeignKey(m => m.ServingId)
                .IsRequired();

            // Review 
            builder.HasMany<Review>(m => m.Reviews)
                .WithOne(r => r.Meal)
                .HasForeignKey(r => r.MealId)
                .IsRequired();
        }
    }
}
