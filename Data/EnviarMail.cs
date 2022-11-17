using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
//using WebApi.Helpers;
namespace MvcMovie.Models
{


    public static class EnviarMail 
    {
        //private readonly AppSettings _appSettings;

   //   public EmailService(IOptions<AppSettings> appSettings)
   //     {
   //         _appSettings = appSettings.Value;
   //     }

        public static void Send(string from, string to, string subject, string html)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("mail.035.com.mx", 465, SecureSocketOptions.StartTls);
            smtp.Authenticate("035netcore@035.com.mx", "?%lf^n273P^2");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}