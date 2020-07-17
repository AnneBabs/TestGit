using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailService.Services
{
    public class EmailServices : IEmailService
    {
        public Task<Response> SendEmailAsync(List<string> to, List<string> cc, string subject, string message)
        {
            return Execute(Environment.GetEnvironmentVariable("SendGrid_ApiKey"), subject, message, cc, to);
        }
        public async Task<Response> Execute(string apiKey, string subject, string message, List<string> to, List<string> cc)
        {

            apiKey = Environment.GetEnvironmentVariable("SendGrid_ApiKey");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("sijuadebabs@gmail.com", "Anne Babawale"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            foreach (var t in to)
            {
                msg.AddTo(new EmailAddress(t));
            }

            foreach (var c in cc)
            {
                msg.AddCc(new EmailAddress(c));
            }

            var response = await client.SendEmailAsync(msg);
            return response;

            

        }
    }
}
