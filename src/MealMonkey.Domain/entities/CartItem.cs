namespace MealMonkey.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal SupTotal { get; set; }


        // Forign Keys
        public Guid CartId { get; set; }
        public Guid MealId { get; set; }

        // Navigation Properties
        public Meal Meal { get; set; }
        public Cart Cart { get; set; }
        public ICollection<CartItemIngredient> CartItemIngrediants { get; set; }
    }
}
