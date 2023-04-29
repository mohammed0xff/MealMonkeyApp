namespace MealMonkey.Application.Services.Mailing
{
    public interface IMailingService
    {
        bool SendEmail(string email, string subject, string message);
    }
}