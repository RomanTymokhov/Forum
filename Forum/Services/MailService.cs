using System.Threading.Tasks;
using Forum.Domain.Services;
using MailKit.Net.Smtp;
using MimeKit;

namespace Forum.Services
{
    public class MailService : IMailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("GfL Forum", "tohoff82@meta.ua"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.meta.ua", 465, true);
                await client.AuthenticateAsync("tohoff82@meta.ua", "Meta20!9");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
