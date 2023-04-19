namespace MealMonkey.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }

        // Forign Keys
        public Guid UserId { get; set; }
        public Guid? OrderId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Order Order { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
