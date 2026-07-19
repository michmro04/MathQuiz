using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz.Services
{
    public static class EmailEngine
    {
        public static async Task SendEmail(string targetEmail,string subject, string body)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential(Secrets.BotEmail, Secrets.BotPassword);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(Secrets.BotEmail, "MathQuiz System");
                    mail.To.Add(targetEmail);
                    mail.Subject = subject;
                    mail.Body = body;

                    await client.SendMailAsync(mail);
                }
            }
        }
    }
}
