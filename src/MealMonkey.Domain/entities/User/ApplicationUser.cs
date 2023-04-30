using MealMonkey.Domain.entities.User;
using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace MealMonkey.Domain.Entities.UserEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;

        // Navigation Properties
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
