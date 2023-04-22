using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.OrderConfigs
{
    public class OrderStatusConfigurations : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            // Properties
            builder.HasKey(x => x.Id);
            
            builder.ToTable(nameof(ApplicationDbContext.OrderStatuses));

            builder.Property(s => s.DateOfEntry)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<string>();

            // Relationships
            //Order
            builder.HasOne<Order>()
                .WithMany(o => o.Statuses)
                .HasForeignKey(s => s.OrderId)
                .IsRequired();
        }
    }
}
