using MealMonkey.Domain.Enums;

namespace MealMonkey.Domain.entities
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime DateOfEntry { get; set; }
        public Status Status { get; set; }
    }
}
