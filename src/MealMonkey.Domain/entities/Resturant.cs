namespace MealMonkey.Domain.Entities
{
    public class Resturant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumpUrl { get; set; }
        public string PhotoUrl { get; set; }

        // relationships
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
