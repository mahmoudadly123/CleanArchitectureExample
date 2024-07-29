using CleanArchitecture.MVC.Services.Contracts;

namespace CleanArchitecture.MVC.Services.Abstract
{
    public class ApiClient:IApiClient
    {
        public ApiClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get; set; }
    }
}
