namespace MealMonkey.Domain.Entities
{
    public class MealOffer
    {
        public Guid MealId { get; set; }
        public Guid OfferId { get; set; }

        // Navigation Properties
        public Meal Meal { get; set; }
        public Offer Offer { get; set; }
    }
}
