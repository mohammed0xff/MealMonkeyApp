using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Descount { get; set; }
        public DateTime CreatedAt { get; set; }


        // relationships
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethodId { get; set; }

        public Guid AddressId { get; set; }
        public UserAddresses Address { get; set; }

        public ICollection<OrderStatus> Statuses { get; set; }
    }
}
