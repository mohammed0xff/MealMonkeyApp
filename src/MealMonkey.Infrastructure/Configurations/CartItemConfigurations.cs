using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Properties
            builder.Property(cartItem =>  cartItem.Quantity).IsRequired();
            builder.Property(cartItem =>  cartItem.SupTotal).IsRequired();

            // Relationships with
            // Cart
            builder.HasOne<Cart>(cartItem => cartItem.Cart)
                .WithMany(cart => cart.CartItems)
                .HasForeignKey(cartItem => cartItem.CartId)
                .IsRequired();
            // Meal
            builder.HasOne<Meal>(cartItem => cartItem.Meal)
                .WithOne()
                .HasForeignKey<CartItem>(cartItem => cartItem.MealId)
                .IsRequired();
        }
    }
}
