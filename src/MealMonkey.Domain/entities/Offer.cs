namespace MealMonkey.Domain.Entities
{
    public class Offer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //relationships
        public string MealId { get; set; }
    }
}
