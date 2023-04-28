namespace MealMonkey.Application.Services.Mailing
{
    public interface IMailingService
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}