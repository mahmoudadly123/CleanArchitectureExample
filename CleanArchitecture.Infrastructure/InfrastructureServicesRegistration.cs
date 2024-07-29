using CleanArchitecture.Application.Interfaces.Infrastructure;
using CleanArchitecture.Infrastructure.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<IEmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSenderService, EmailSenderService>();

            return services;
        }
    }
}
