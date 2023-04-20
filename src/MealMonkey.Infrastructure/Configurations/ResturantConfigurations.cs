using MealMonkey.Domain.Entities.ResturantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class ResturantConfigurations : IEntityTypeConfiguration<Resturant>
    {
        public void Configure(EntityTypeBuilder<Resturant> builder)
        {
            // Properties
            builder.Property(r => r.Name)
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(r => r.Description)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
