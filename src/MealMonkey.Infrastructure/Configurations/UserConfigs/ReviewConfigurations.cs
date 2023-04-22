using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.UserConfigs
{
    public class ReviewConfigurations : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // Properties
            builder.Property(r => r.Stars)
              .IsRequired();
            
            builder.ToTable(nameof(ApplicationDbContext.Reviews));


            builder.Property(r => r.Comment)
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(r => r.CreatedAt)
               .IsRequired()
               .HasDefaultValue(DateTime.UtcNow);

            // Relationships
            // User
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .IsRequired();

            // Meal
            builder.HasOne(r => r.Meal)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MealId)
                .IsRequired();
        }
    }
}
