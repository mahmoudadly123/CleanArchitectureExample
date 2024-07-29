using System.Reflection;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.Services.Implement;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanArchitecture.MVC
{
    public static class MvcServicesRegistration
    {
        public static IServiceCollection AddMvcServices(this IServiceCollection services,IConfiguration configuration)
        {
            //Register Services inside Dependency Injection System

            var apiUrl = configuration.GetSection("api").Value;

            services.Configure<CookiePolicyOptions>(cookieOptions =>
            {
                cookieOptions.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddControllersWithViews();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpClient<IApiClient, ApiClient>(c=>c.BaseAddress=new Uri(apiUrl!));
            services.AddHttpContextAccessor();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


            services.AddSingleton<ILocalStorageService, LocalStorageService>();
            
            services.AddScoped<IBooksService, BooksService>();

            services.AddTransient<IIdentityService, IdentityService>();


            return services;
        }
    }
}
