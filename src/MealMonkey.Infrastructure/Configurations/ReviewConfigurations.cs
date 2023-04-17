using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    internal class ReviewConfigurations : IEntityTypeConfiguration<Review>
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
