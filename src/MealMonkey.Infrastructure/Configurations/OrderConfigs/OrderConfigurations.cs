using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.OrderConfigs
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Properties
            builder.Property(order => order.DeliveryFee).IsRequired();
            builder.Property(order => order.TotalPrice).IsRequired();
            builder.Property(order => order.Discount).IsRequired();

            builder.Property(order => order.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            // Relationships with
            // User
            builder.HasOne(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId)
                .IsRequired();

            // Payment Methods
            builder.HasOne(order => order.PaymentMethod)
                .WithMany()
                .HasForeignKey(order => order.PaymentMethodId)
                .IsRequired();

            // Adress
            builder.HasOne(order => order.Address)
                .WithMany()
                .HasForeignKey(order => order.AddressId)
                .IsRequired();
        }
    }
}
