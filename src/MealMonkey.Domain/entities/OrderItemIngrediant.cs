
namespace MealMonkey.Domain.Entities
{
    public class OrderItemIngrediant
    {
        public Guid OrderItemId { get; set; }
        public Guid IngrediantId { get; set; }

        // Navigation Properties
        public ICollection<Ingrediant> Ingrediants { get; set; }
    }
}
