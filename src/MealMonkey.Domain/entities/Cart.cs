namespace MealMonkey.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }

        // Forign Keys
        public Guid UserId { get; set; }

        // Navigation Properties
        public User User { get; set; }
    }
}
