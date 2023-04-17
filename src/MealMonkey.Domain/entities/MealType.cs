namespace MealMonkey.Domain.Entities
{
    public class MealType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navegation Properties
        public ICollection<Meal> Meals { get; set; }
    }
}