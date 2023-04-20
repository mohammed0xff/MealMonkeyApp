namespace MealMonkey.Domain.Entities.AddressEntities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Details { get; set; }

        // Forign Keys
        public Guid CityId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ResturantId { get; set; }

        // Navigation Properties
        public City City { get; set; }

    }
}
