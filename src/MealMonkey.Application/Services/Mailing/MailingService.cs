namespace MealMonkey.Application.Services.Mailing
{
    public class MailingService : IMailingService
    {
        public async Task<bool> SendEmailAsync(string mailTo, string subject, string body)
        {

            return true;
        }
    }
}