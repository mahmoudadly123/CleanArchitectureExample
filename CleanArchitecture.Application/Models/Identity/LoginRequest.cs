namespace CleanArchitecture.Application.Models.Identity
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string SecurityStamp { get; set; } = "123";
    }
}
