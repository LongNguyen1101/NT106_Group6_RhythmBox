using Microsoft.VisualBasic;
using RhythmBox.Data;
using RhythmBox.Models;
using RhythmBox.Repositories.Interface;
using RhythmBox.Repositories;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using RhythmBox.Repositories.Services;
using NuGet.Protocol.Core.Types;

namespace RhythmBox.Repositories.Services
{
    public class ForgotPassword : IForgotPassword
    {
        private void SendEmail(string emailDestination, int OTP) 
        {
            var fromEmail = new MailAddress("tiendat9tc@gmail.com");
            var toAddress = new MailAddress(emailDestination);
            string fromPassword = "swtmodttgwdybfty";
            string subject = "OTP Code";
            string body = OTP.ToString();

            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromPassword),
                Timeout = 200000
            };

            using (var msg = new MailMessage(fromEmail, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(msg);
            }
        }

        public int? forgotPassword(RhythmboxdbContext context, string email)
        {
            var exists = (from user in context.Users
                          where user.Email == email
                          select user).FirstOrDefault();
            if (exists == null) 
            {
                return null;
            }

            Random random = new Random();
            int OTP = random.Next(100000, 1000000);

            SendEmail(exists.Email!, OTP);

            return OTP;
        }

        public async Task<User?> renewPassword(RhythmboxdbContext context, string email, string newPassword)
        {
            var exists = await Task.Run(() => (from user in context.Users
                          where user.Email == email
                          select user).FirstOrDefault());

            if (exists == null)
            {
                return null;
            }

            exists.UserPassword = newPassword;

            context.Users.Update(exists);
            context.SaveChanges();

            return exists;
        }
    }
}
