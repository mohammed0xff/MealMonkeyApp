namespace MealMonkey.Domain.Entities
{
    public class CartItemIngrediant
    {
        public Guid CartItemId { get; set; }

        // Forign Keys
        public Guid IngrediantId { get; set; }
    }
}