
namespace MealMonkey.Domain.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
    }
}
