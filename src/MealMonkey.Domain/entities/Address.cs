namespace MealMonkey.Domain.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Details { get; set; }


        // relationships
        public string CityId { get; set; }
        public City City { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Resturant> Resturants { get; set; }
    }
}
