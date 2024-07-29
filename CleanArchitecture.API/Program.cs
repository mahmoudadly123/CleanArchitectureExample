using CleanArchitecture.API.Infrastructure;
using CleanArchitecture.Application;
using CleanArchitecture.Identity;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence;


namespace CleanArchitecture.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Config services to the container.
            builder.Services.AddApplicationServices()
                            .AddInfrastructureServices(builder.Configuration)
                            .AddPersistenceServices(builder.Configuration)
                            .AddIdentityServices(builder.Configuration)
                            .AddApiServices();

            // Build Application
            var app = builder.Build();

            // Configure the HTTP request pipeline. (Middleware)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            //Configure Security
            app.UseAuthentication();
            app.UseAuthorization();

            //Map Endpoints
            app.UseRouting();
            app.MapControllers(); //Endpoints over Controller classes
            app.MapEndpoints(); //Endpoints inside files

            //Start Application
            app.Run();
        }
    }
}