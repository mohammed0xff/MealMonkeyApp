using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class ReviewConfigurations : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            // Properties
            builder.Property(r => r.CreatedAt)
               .IsRequired();
            builder.Property(r => r.Stars)
              .IsRequired();
            builder.Property(r => r.Comment)
                .HasMaxLength(200)
               .IsRequired();

            // Relationships
           
        }
    }
}
