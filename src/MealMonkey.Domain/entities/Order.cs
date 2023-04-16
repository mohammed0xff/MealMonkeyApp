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
        public string Id { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Descount { get; set; }
        public DateTime CreatedAt { get; set; }


        // relationships
        public string UserId { get; set; }
        public User User { get; set; }

        public string PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public string AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<OrderStatus> Statuses { get; set; }
    }
}
