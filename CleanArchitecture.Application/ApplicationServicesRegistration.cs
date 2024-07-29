using System.Reflection;
using CleanArchitecture.Application.Mediators.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Register All AutoMapper Profiles (MappingProfile) inside Dependency Injection System
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Register Mediator Services Configurations inside Dependency Injection System
            services.AddMediatR((config) =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient<INotificationPublisher, NotificationPublisher>();


            return services;
        }
    }
}
