using MealMonkey.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.OrderConfigs
{
    public class PaymentMethodConfigurations : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            // Properties
            builder.HasKey(x => x.Id);
            
            builder.ToTable(nameof(ApplicationDbContext.PaymentMethods));

            builder.Property(p => p.Fee)
                .IsRequired()
                .HasPrecision(18, 4);

            builder.Property(p => p.Name)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
