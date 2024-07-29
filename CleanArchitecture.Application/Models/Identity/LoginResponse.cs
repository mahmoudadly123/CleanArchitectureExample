using System.Security.Claims;

namespace CleanArchitecture.Application.Models.Identity
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
        
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public List<Claim> UserClaims { get; set; }
    }
}
