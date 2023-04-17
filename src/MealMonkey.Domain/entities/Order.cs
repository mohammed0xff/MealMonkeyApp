
namespace MealMonkey.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderStatus { get; set; }

        // Forign Keys
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid AddressId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Address Address { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
