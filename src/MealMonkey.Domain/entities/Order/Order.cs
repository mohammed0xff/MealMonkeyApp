﻿using MealMonkey.Domain.Entities.AddressEntities;
using MealMonkey.Domain.Entities.CartEntities;
using MealMonkey.Domain.Entities.UserEntities;

namespace MealMonkey.Domain.Entities.OrderEntities
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }

        // Forign Keys
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid AddressId { get; set; }
        public Guid CartId { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Address Address { get; set; }
        public Cart Cart { get; set; }
        public ICollection<OrderStatus> Statuses { get; set; }
    }
}
