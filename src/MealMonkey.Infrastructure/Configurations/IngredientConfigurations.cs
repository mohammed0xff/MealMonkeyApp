using MealMonkey.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealMonkey.Infrastructure.Configurations
{
    internal class IngredientConfigurations : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            // Properties
            builder.Property(ingredient => ingredient.Price)
                .IsRequired();
            builder.Property(ingredient => ingredient.Name)
                .IsRequired()
                .HasMaxLength(40);

            // Relationships with

            // CartItemIngredient
            builder.HasMany<CartItemIngredient>()
                .WithOne(cartItemIngredient => cartItemIngredient.Ingredient)
                .HasForeignKey(cartItemIngredient => cartItemIngredient.IngrediantId)
                .IsRequired();

            // OrderItemIngredients
            builder.HasMany<OrderItemIngredient>()
                .WithOne(orderItemIngredient => orderItemIngredient.Ingrediant)
                .HasForeignKey(orderItemIngredient => orderItemIngredient.IngrediantId)
                .IsRequired();
        }
    }
}
