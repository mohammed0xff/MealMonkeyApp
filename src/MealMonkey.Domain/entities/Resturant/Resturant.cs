using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.MealEntities;

namespace MealMonkey.Domain.Entities.ResturantEntities
{
    public class Resturant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<ResturantPhoneNumber> ResturantPhoneNumbers { get; set; }
    }
}
