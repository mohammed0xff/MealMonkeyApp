namespace MealMonkey.Domain.Entities
{
    public class CartItemIngredient
    {
        // Forign Keys
        public Guid CartItemId { get; set; }
        public Guid IngrediantId { get; set; }

        // Navigation Properties
        public Ingredient Ingredient { get; set; }
    }
}