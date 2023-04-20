using MealMonkey.Domain.Entities.MealEntities;

namespace MealMonkey.Domain.Entities.UserEntities
{
    public class Review
    {
        public Guid Id { get; set; }
        public float Stars { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        // Forign Keys
        public Guid UserId { get; set; }
        public Guid MealId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Meal Meal { get; set; }
    }
}
