using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request);

        Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
    }
}
