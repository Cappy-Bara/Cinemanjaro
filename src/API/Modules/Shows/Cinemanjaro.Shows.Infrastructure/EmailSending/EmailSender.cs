using Cinemanjaro.Common.Settings;
using Cinemanjaro.Shows.Application.EmailSending;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Cinemanjaro.Shows.Infrastructure.EmailSending
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly EmailSettings _emailSettings;
        public EmailSender(IOptions<EmailSettings> settings)
        {
            _emailSettings = settings.Value;

            _smtpClient = new SmtpClient
            {
                Host = _emailSettings.SmtpHost,
                Port = _emailSettings.SmtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password)
            };
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            using var message = new MailMessage(_emailSettings.Email, to)
            {
                Subject = subject,
                Body = body,
            };
            try
            {
                await _smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message Cannot be sent. Error: ");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
