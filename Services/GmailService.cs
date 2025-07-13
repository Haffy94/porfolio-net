using System.Threading.Tasks;
using Portafolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portafolio.Services
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
                $"Un nuevo cliente te ha contactado:{contact.Name}, su mail de contacto es {contact.Email}",
                    contact.Message);

            await smtpClient.SendMailAsync(message);
        }
    }
}