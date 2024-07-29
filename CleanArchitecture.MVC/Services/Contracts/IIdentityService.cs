namespace CleanArchitecture.MVC.Services.Contracts;

public interface IIdentityService
{
    Task<bool> Login(string username, string password,string securityStamp);
    Task Logout();

    Task<bool> Register(string username, string password,string email);
}