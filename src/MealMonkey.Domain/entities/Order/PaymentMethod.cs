namespace MealMonkey.Domain.Entities.OrderEntities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
    }
}
