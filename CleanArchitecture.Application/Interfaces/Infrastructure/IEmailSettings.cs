namespace CleanArchitecture.Application.Interfaces.Infrastructure
{
    public interface IEmailSettings
    {
        string ApiKey { get; set; }
        string ApiSecret { get; set; }
        string SenderAddress { get; set; }
        string SenderName { get; set; }
    }
}
