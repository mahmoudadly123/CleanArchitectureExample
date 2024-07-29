using CleanArchitecture.Application.Interfaces.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identity.Services;

public class UserService:IUserService
{
    private readonly UserManager<ApplicationUser<Guid>> _userManager;

    public UserService(UserManager<ApplicationUser<Guid>> userManager)
    {
        _userManager=userManager;
    }

    public async Task<List<User>> GetUsers()
    {
        var users =await _userManager.GetUsersInRoleAsync("Users");

        return users.Select(appUser=>new User
        {
            UserId = appUser.Id.ToString(),
            UserName = appUser.UserName,
            UserEmail = appUser.Email!
        }).ToList();
    }

    public async Task<List<User>> GetSupervisors()
    {
        var supervisors = await _userManager.GetUsersInRoleAsync("Supervisors");

        return supervisors.Select(appUser => new User
        {
            UserId = appUser.Id.ToString(),
            UserName = appUser.UserName,
            UserEmail = appUser.Email!
        }).ToList();
    }

    public async Task<List<User>> GetAdministrators()
    {
        var administrators = await _userManager.GetUsersInRoleAsync("Administrators");

        return administrators.Select(appUser => new User
        {
            UserId = appUser.Id.ToString(),
            UserName = appUser.UserName,
            UserEmail = appUser.Email!
        }).ToList();
    }
}