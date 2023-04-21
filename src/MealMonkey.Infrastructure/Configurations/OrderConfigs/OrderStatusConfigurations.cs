using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using MealMonkey.Domain.OrderEntities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.OrderConfigs
{
    public class OrderStatusConfigurations : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            // Properties
            builder.Property(s => s.DateOfEntry)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion(s => s.ToString(), sAsString => (OrderStatusType)Enum.Parse(typeof(OrderStatusType), sAsString));

            // Relationships
            //Order
            builder.HasOne<Order>()
                .WithMany(o => o.Statuses)
                .HasForeignKey(s => s.OrderId)
                .IsRequired();
        }
    }
}
