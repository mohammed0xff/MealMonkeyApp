namespace MealMonkey.Domain.Entities
{
    public class Review
    {
        public string Id { get; set; }
        public Decimal Stars { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }


        // relationship
        public string UserId { get; set; }
        public User User { get; set; }

        public string MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
