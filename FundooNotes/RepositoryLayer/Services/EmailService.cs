using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailService
    {
        public static void SendMail(string Email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("dp8521037@gmail.com", "Pdevendra@1234");
                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(Email);
                msgObj.From = new MailAddress("dp8521037@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"www.fundooNotes.com/reset-password/{token}";
                client.Send(msgObj);
            }
        }
    }
}
