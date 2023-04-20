namespace MealMonkey.Domain.Entities.ResturantEntities
{
    public class ResturantPhoneNumber
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }

        //relationships
        public Guid ResturantId { get; set; }
        public Resturant Resturant { get; set; }
    }
}
