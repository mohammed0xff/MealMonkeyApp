using MealMonkey.Domain.entities.Order.Enums;

namespace MealMonkey.Domain.Entities.OrderEntities
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public OrderStatusType Status { get; set; }
    }
}
