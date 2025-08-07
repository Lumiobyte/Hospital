using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public static class Emails
    {


        public static void SendEmail(string toEmail, string subject, string body)
        {
            var fromEmail = "hospitaldotnet2@gmail.com";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, "klhb kxjj hpgf fqom"),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            mailMessage.To.Add(toEmail);
            client.Send(mailMessage);
        }

    }
}
