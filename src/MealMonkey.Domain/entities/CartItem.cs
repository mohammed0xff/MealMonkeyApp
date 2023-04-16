namespace MealMonkey.Domain.Entities
{
    public class CartItem
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal SupTotal { get; set; }


        // relationships
        public string CartId { get; set; }

        public string MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
