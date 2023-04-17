using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class PaymentMethodConfigurations : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            // Properties
            builder.Property(pm => pm.Fee)
                .IsRequired();
            builder.Property(pm => pm.Name)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
