using CleanArchitecture.MVC.Services.Contracts;

namespace CleanArchitecture.MVC.Services.Abstract
{

    public class ApiResponse : IApiResponse
    {
        public ApiResponse()
        {
            Message = string.Empty;
            ValidationErrors = new();
            IsSuccess = true;
        }

        public ApiResponse(string message)
        {
            Message = message;
            ValidationErrors = new ();
        }
        public ApiResponse(string message, List<string> validationErrors)
        {
            Message = message;
            ValidationErrors = validationErrors;
        }
        public ApiResponse(bool isSuccess,string message, List<string> validationErrors)
        {
            Message = message;
            ValidationErrors = validationErrors;
            IsSuccess = isSuccess;
        }


        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public bool IsSuccess { get; set; }
    }

    public class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse()
        {
            Message = string.Empty;
            ValidationErrors = new();
            IsSuccess = true;
            HasData = false;
            Data = default(T)!;
        }
        public ApiResponse(string message, List<string> validationErrors, bool isSuccess, bool hasData, T data)
        {
            Message = message;
            ValidationErrors = validationErrors;
            IsSuccess = isSuccess;
            HasData = hasData;
            Data = data;
        }

        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public bool IsSuccess { get; set; }

        public bool HasData { get; set; }
        public T Data { get; set; }
    }
}
