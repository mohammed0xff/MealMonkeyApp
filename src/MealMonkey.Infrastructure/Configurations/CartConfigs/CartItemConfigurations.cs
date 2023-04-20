using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.MealEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations.CartConfigs
{
    public class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Properties
            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.SupTotal).IsRequired();

            // Relationships with
            // Cart
            builder.HasOne(i => i.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.CartId)
                .IsRequired();

            // Meal
            builder.HasOne(i => i.Meal)
                .WithMany()
                .HasForeignKey(i => i.MealId)
                .IsRequired();
        }
    }
}
