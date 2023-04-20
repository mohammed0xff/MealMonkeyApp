/*using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class OrderItemIngredientConfigurations : IEntityTypeConfiguration<OrderItemIngredient>
    {
        public void Configure(EntityTypeBuilder<OrderItemIngredient> builder)
        {
            // Primary composite key
            builder.HasKey(orderItemIngrediant =>
            new { orderItemIngrediant.OrderItemId, orderItemIngrediant.IngrediantId });

            // Relationships with
            // OrderItem
            builder.HasOne<OrderItem>()
                .WithMany(orderItem => orderItem.OrderItemIngredients)
                .HasForeignKey(orderItemIngredient => orderItemIngredient.OrderItemId)
                .IsRequired();
        }
    }
}
*/