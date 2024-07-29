namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IApiClient
    {
        HttpClient Client { get; set; }
    }
}
