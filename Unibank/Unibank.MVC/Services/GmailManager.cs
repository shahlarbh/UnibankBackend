using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Unibank.MVC.Data;


namespace Unibank.MVC.Services
{
    public class GmailManager : IMailService
    {
        private readonly MailSetting _mailSetting;

        public GmailManager(IOptions<MailSetting> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }

        public async Task SendEmailAsync(RequestEmail requestEmail)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_mailSetting.Email)
                };

                email.To.Add(MailboxAddress.Parse(requestEmail.ToEmail));
                email.Subject = requestEmail.Subject;

                var builder = new BodyBuilder
                {
                    HtmlBody = requestEmail.Body
                };

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSetting.Email, _mailSetting.Password);

                await smtp.SendAsync(email);

                smtp.Disconnect(true);
            }

            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
