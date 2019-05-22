using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Service
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
            //return Execute("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", subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            //Essai : 
            //apiKey = Environment.GetEnvironmentVariable("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");

            try
            {
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("randy.leclerc02@gmail.com", "Randy"),
                    Subject = subject,
                    PlainTextContent = message,
                    HtmlContent = message
                };
                msg.AddTo(new EmailAddress(email));

                // Disable click tracking.
                // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
                msg.SetClickTracking(false, false);

                return client.SendEmailAsync(msg);
            }
            catch
            {
                throw new Exception("Email not send...");
            }

        }
    }
}
