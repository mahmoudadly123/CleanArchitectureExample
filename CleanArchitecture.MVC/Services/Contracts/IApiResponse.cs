namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IApiResponse
    {
        string Message { get; set; }
        List<string> ValidationErrors { get; set; }
        bool IsSuccess { get; set; }
    }

    public interface IApiResponse<T>: IApiResponse
    {
        bool HasData { get; set; }
        T Data { get; set; }
    }
}
