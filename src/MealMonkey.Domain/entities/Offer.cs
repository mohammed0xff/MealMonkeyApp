namespace MealMonkey.Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public decimal Discount { get; set; }
        public string Title { get; set; }
        public DateTime Details { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation Properties
        public ICollection<MealOffer> MealOffers { get; set; }
    }
}
