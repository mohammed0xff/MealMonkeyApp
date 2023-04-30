using MealMonkey.Application.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace MealMonkey.Application.Services.Mailing
{
    public class MailingService : IMailingService
    {
        private readonly MailingSettings _mailingSetting;
        public MailingService(IOptions<MailingSettings> options)
        {
            _mailingSetting = options.Value;
        }

        public bool SendEmail(string mailTo, string subject, string body)
        {
            MailMessage message = new();
            message.From = new MailAddress(_mailingSetting.Email);
            message.To.Add(new MailAddress(mailTo));

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            SmtpClient smtp = new();
            smtp.Port = _mailingSetting.Port;
            smtp.Host = _mailingSetting.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential(_mailingSetting.Email, _mailingSetting.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}