using CleanArchitecture.Application.Models.Identity;

namespace CleanArchitecture.Application.Interfaces.Identity;

public interface IUserService
{
    /// <summary>
    /// Get All Users inside Role Users
    /// </summary>
    /// <returns></returns>
    Task<List<User>> GetUsers();

    /// <summary>
    /// Get All Users inside Role Supervisors
    /// </summary>
    /// <returns></returns>
    Task<List<User>> GetSupervisors();

    /// <summary>
    /// Get All Users inside Role Administrators
    /// </summary>
    /// <returns></returns>
    Task<List<User>> GetAdministrators();
}