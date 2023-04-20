using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using MealMonkey.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Properties
            builder.Property(order => order.DeliveryFee).IsRequired();
            builder.Property(order => order.TotalPrice).IsRequired();
            builder.Property(order => order.Discount).IsRequired();
            builder.Property(order => order.CreatedAt).IsRequired();
            builder.Property(order => order.OrderStatus).IsRequired();

            // Relationships with
            // user
            builder.HasOne<User>(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId)
                .IsRequired();

            // payment methods
            builder.HasOne<PaymentMethod>(order => order.PaymentMethod)
                .WithMany()
                .HasForeignKey(order => order.PaymentMethodId)
                .IsRequired();

            // adresses
            builder.HasOne<Address>(order => order.Address)
                .WithMany()
                .HasForeignKey(order => order.AddressId)
                .IsRequired();
        }
    }
}
