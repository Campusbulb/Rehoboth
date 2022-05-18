using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.Extensions.Configuration;

using MimeKit;

using System.Collections.Generic;

namespace Rehoboth.Helper
{
    public class MailHelper4
    {
        private readonly IConfiguration _configuration;

        public MailHelper4(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool RegisterNur(string from, string to, string subject, string content, List<string> attachments)
        {
            try
            {
                var username = _configuration["Gmail:Username"];
                var password = _configuration["Gmail:Password"];


                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = "Volunteer Application";
                var builder = new BodyBuilder
                {
                    HtmlBody = string.Format(content)
                };

                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        builder.Attachments.Add(attachment);
                    }
                }

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.Auto);
                smtp.Authenticate(username, password);
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
