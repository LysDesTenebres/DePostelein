using LightBuzz.SMTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;

namespace DePosteleinManagement.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync (String adress, String username, String password) {

            using (SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587, false, "email", "password"))
            {
                EmailMessage emailMessage = new EmailMessage();

                emailMessage.To.Add(new EmailRecipient(adress));
                emailMessage.Subject = "DePostelein Account";
                emailMessage.Body = "Account: " + username + "\r\nPassword: " + password;

                await client.SendMailAsync(emailMessage);
            }

        }
       
    }
}
