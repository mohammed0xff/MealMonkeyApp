using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.OrderEntities;

namespace MealMonkey.Domain.Entities.UserEntities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public string HashPassword { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
