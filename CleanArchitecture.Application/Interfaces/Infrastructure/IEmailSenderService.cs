using CleanArchitecture.Application.Models.Infrastructure;

namespace CleanArchitecture.Application.Interfaces.Infrastructure
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
