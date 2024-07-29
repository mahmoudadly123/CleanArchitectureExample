using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using CleanArchitecture.Application.Interfaces.Infrastructure;
using CleanArchitecture.Application.Models.Infrastructure;

namespace CleanArchitecture.Infrastructure.Services.Email
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSettings _emailSettings;

        public EmailSenderService(IOptions<EmailSettings> emailSettingsOptions)
        {
            _emailSettings = emailSettingsOptions.Value;
        }

        public async Task<bool> SendEmailAsync(Application.Models.Infrastructure.Email email)
        {
            var fromAddress = new EmailAddress(_emailSettings.SenderAddress, _emailSettings.SenderName);
            var toAddress = new EmailAddress(email.To, email.Name);
            var contentMessage = MailHelper.CreateSingleEmail(fromAddress, toAddress, email.Subject, email.Body, email.Body);

            var response = await new SendGridClient(_emailSettings.ApiKey).SendEmailAsync(contentMessage);

            return response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK;
        }
    }
}
