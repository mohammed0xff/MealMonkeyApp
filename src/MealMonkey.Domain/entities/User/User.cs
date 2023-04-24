using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace MealMonkey.Domain.Entities.UserEntities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation Properties
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
