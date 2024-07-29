using CleanArchitecture.Application.Interfaces.Infrastructure;

namespace CleanArchitecture.Application.Models.Infrastructure
{
   

    public class EmailSettings : IEmailSettings
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public string SenderAddress { get; set; }
        public string SenderName { get; set; }
    }
}
