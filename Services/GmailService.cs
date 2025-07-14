using System.Threading.Tasks;
using Portfolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portfolio.Services
{
    public interface IGmailService
    {
        Task SendContact(ContactViewModel contact);
    }

    public class GmailService : IGmailService
    {
        private readonly IConfiguration configuration;
        public GmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendContact(ContactViewModel contact)
        {
            var EmailSender = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATIONS:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATIONS:PORT");

            var smtpClient = new SmtpClient(host, port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential(EmailSender, password);
            var message = new MailMessage(EmailSender, EmailSender,
                $"Un nuevo cliente te ha contactado:{contact.Name}",
                $"mail de contacto {contact.Email}, Mensaje:{contact.Message}");
            await smtpClient.SendMailAsync(message);
        }
    }
}