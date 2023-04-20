namespace MealMonkey.Domain.Entities.MealEntities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Meal> Meals { get; set; }
    }
}
