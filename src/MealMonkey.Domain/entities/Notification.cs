

namespace MealMonkey.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ReadDate { get; set; }

        // Forign Keys
        public Guid UserId { get; set; }
        
        // Navigation Propert
        public User User { get; set; }

    }
}
