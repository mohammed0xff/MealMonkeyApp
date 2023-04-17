
namespace MealMonkey.Domain.Entities
{
    public class OrderItemIngredient
    {
        public Guid OrderItemId { get; set; }
        public Guid IngrediantId { get; set; }

        // Navigation Properties
        public Ingredient Ingrediant { get; set; }
    }
}
