using MealMonkey.Domain.Entities.MealEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.MealConfigs
{
    public class MealTypeConfigurations : IEntityTypeConfiguration<MealType>
    {
        public void Configure(EntityTypeBuilder<MealType> builder)
        {
            // Properties
            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
