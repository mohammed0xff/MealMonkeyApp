/*using MealMonkey.Domain.Entities.CartEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    public class CartItemIngredientConfigurations : IEntityTypeConfiguration<CartItemIngredient>
    {
        public void Configure(EntityTypeBuilder<CartItemIngredient> builder)
        {
            // Primary composite key
            builder.HasKey(cartItemIngrediant =>
            new { cartItemIngrediant.CartItemId, cartItemIngrediant.IngrediantId });
            // Relationships with
            // Ingredient
            builder.HasOne<CartItem>()
                .WithMany(cartItem => cartItem.CartItemIngrediants)
                .HasForeignKey(cartItemIngredient => cartItemIngredient.CartItemId)
                .IsRequired();
        }
    }
}
*/