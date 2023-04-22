using MealMonkey.Domain.Entities.ResturantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.ResturantConfigs
{
    public class ResturantConfigurations : IEntityTypeConfiguration<Resturant>
    {
        public void Configure(EntityTypeBuilder<Resturant> builder)
        {
            // Properties
            builder.HasKey(x => x.Id);
            
            builder.ToTable(nameof(ApplicationDbContext.Resturants));

            builder.Property(r => r.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
