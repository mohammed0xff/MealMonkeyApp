
namespace MealMonkey.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public decimal SupTotal { get; set; }
        public int Quantity { get; set; }


        // Forign Keys
        public Guid MealId { get; set; }
        public Guid OrderId { get; set; }

        // Navigation Properties
        public Meal Meal { get; set; }
    }
}
