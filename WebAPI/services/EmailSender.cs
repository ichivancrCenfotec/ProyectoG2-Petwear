using static System.Net.WebRequestMethods;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebAPI.services
{
    public class EmailSender
    {
        public async Task SendEmail(string toEmail, string username,string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("aulateu@ucenfotec.ac.cr", "Petwear");
            var subject = "correo verificación";
            var to = new EmailAddress(toEmail , username);
            var plainTextContent = message;
            var htmlContent = "" ;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
