using MealMonkey.Domain.Entities.MealEntities;
using MealMonkey.Domain.Entities.ResturantEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class MealConfigurations : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(40)
                .IsRequired();


            // Relationships
            // Category
            builder.HasOne<Category>(m => m.Category)
                .WithMany(c => c.Meals)
                .HasForeignKey(m => m.CategoryId)
                .IsRequired();

            // Resturant
            builder.HasOne<Resturant>(m => m.Resturant)
                .WithMany(r => r.Meals)
                .HasForeignKey(m => m.ResturantId)
                .IsRequired();

            // MealType
            builder.HasOne<MealType>(m => m.MealType)
                .WithMany(mt => mt.Meals)
                .HasForeignKey(m => m.MealTypeId)
                .IsRequired();

            // Review 
            builder.HasMany<Review>(m => m.Reviews)
                .WithOne(r => r.Meal)
                .HasForeignKey(r => r.MealId)
                .IsRequired();
        }
    }
}
