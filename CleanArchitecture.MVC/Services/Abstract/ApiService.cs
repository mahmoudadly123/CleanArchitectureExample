using System.Net;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using CleanArchitecture.MVC.Services.Contracts;
//using System.Text.Json;
//using System.Text;
using CleanArchitecture.Application.Serialization.JsonConverters;
using CleanArchitecture.Common.Results;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace CleanArchitecture.MVC.Services.Abstract
{
    public abstract class ApiService:IApiService
    {
        protected IMapper Mapper;
        protected IApiClient ApiClient;
        protected readonly ILocalStorageService LocalStorage;


        protected ApiService(IMapper mapper,IApiClient apiClient,ILocalStorageService localStorage)
        {
            ApiClient = apiClient;
            LocalStorage = localStorage;
            Mapper=mapper;
        }

        protected void AddBearerTokenInRequestHeader()
        {
            if (LocalStorage.Exist("token"))
            {
                ApiClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.GetStorageValue<string>("token"));
            }
        }

        #region Rest API Helper



        public async Task<ApiResponse<Tvm>> GetAsync<Tdto,Tvm>(string uriPath)
        {
            var requestUri = $"{ApiClient.Client.BaseAddress}/{uriPath}";

            //Add Authentication Token to Header Request if exist
            AddBearerTokenInRequestHeader();

            // Send the request and get the response.
            var responseMessage = await ApiClient.Client.GetAsync(requestUri);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            //result of function
            var result = new ApiResponse<Tvm>();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:

                    // Deserialize string To Object
                    var queryResponse = JsonConvert.DeserializeObject<Result<Tdto>>(responseContent);

                    //Convert List<UserDto> to List<UserViewModel> powered by autoMapper
                    result.Data = Mapper.Map<Tvm>(queryResponse!.Value);
                    result.IsSuccess = true;
                    result.HasData = true;

                    break;

                case HttpStatusCode.NoContent:
                    result.IsSuccess = true;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;

                case HttpStatusCode.BadRequest:
                    result.IsSuccess = false;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;

                default:
                    result.IsSuccess = false;
                    result.HasData = false;
                    break;
            }

            return result;
        }

        public async Task<ApiResponse<Tvm>> PostAsync<Tdto, Tvm>(string uriPath,object data)
        {
            var requestUri = $"{ApiClient.Client.BaseAddress}/{uriPath}";

            //Serialize data object to string
            var jsonText = JsonConvert.SerializeObject(data);

            // Create a StringContent object.
            var content = new StringContent(jsonText, Encoding.UTF8, "application/json");

            //Add Authentication Token to Header Request if exist
            AddBearerTokenInRequestHeader();

            // Send the request and get the response.
            var responseMessage = await ApiClient.Client.PostAsync(requestUri, content);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            //result of function
            var result = new ApiResponse<Tvm>();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.Created:

                    // Deserialize string To Object
                    var queryResponse = JsonConvert.DeserializeObject<Result<Tdto>>(responseContent);

                    //Convert List<UserDto> to List<UserViewModel> powered by autoMapper
                    result.Data = Mapper.Map<Tvm>(queryResponse!.Value);
                    result.IsSuccess = true;
                    result.HasData = true;

                    break;

                case HttpStatusCode.BadRequest:
                    result.IsSuccess = false;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;

                default:
                    result.IsSuccess = false;
                    result.HasData = false;
                    break;
            }

            return result;
        }

        public async Task<ApiResponse<TServiceResponse>> PostAsync<TServiceResponse>(string uriPath, object data)
        {
            var requestUri = $"{ApiClient.Client.BaseAddress}/{uriPath}";

            //Serialize data object to string
            var jsonText = JsonConvert.SerializeObject(data);

            // Create a StringContent object.
            var content = new StringContent(jsonText, Encoding.UTF8, "application/json");

            //Add Authentication Token to Header Request if exist
            AddBearerTokenInRequestHeader();

            // Send the request and get the response.
            var responseMessage = await ApiClient.Client.PostAsync(requestUri, content);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            //result of function
            var result = new ApiResponse<TServiceResponse>();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:

                    result.Data = JsonConvert.DeserializeObject<TServiceResponse>(responseContent, new ClaimJsonConverter())!;
                    result.IsSuccess = true;
                    result.HasData = true;
                    result.Message = responseContent;

                    break;

                case HttpStatusCode.Created:

                    result.Data = JsonConvert.DeserializeObject<TServiceResponse>(responseContent, new ClaimJsonConverter())!;
                    result.IsSuccess = true;
                    result.HasData = true;
                    result.Message = responseContent;


                    break;

                case HttpStatusCode.BadRequest:
                    result.IsSuccess = false;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;

                default:
                    result.IsSuccess = false;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;
            }

            return result;
        }

        public async Task<ApiResponse<Tvm>> PutAsync<Tdto, Tvm>(string uriPath, object data)
        {
            var requestUri = $"{ApiClient.Client.BaseAddress}/{uriPath}";

            //Serialize data object to string
            var jsonText = JsonConvert.SerializeObject(data);

            // Create a StringContent object.
            var content = new StringContent(jsonText, Encoding.UTF8, "application/json");

            //Add Authentication Token to Header Request if exist
            AddBearerTokenInRequestHeader();

            // Send the request and get the response.
            var responseMessage = await ApiClient.Client.PutAsync(requestUri, content);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            //result of function
            var result = new ApiResponse<Tvm>();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:

                    // Deserialize string To Object
                    var commandResponseDto = JsonConvert.DeserializeObject<Result<Tdto>>(responseContent);

                    //Convert List<UserDto> to List<UserViewModel> powered by autoMapper
                    result.Data = Mapper.Map<Tvm>(commandResponseDto!.Value);
                    result.IsSuccess = true;
                    result.HasData = true;

                    break;

                case HttpStatusCode.NoContent:

                    // Deserialize string To Object
                    var responseDto = JsonConvert.DeserializeObject<Result<Tdto>>(responseContent);

                    // Convert List<UserDto> to List<UserViewModel> powered by autoMapper
                    result.Data = Mapper.Map<Tvm>(responseDto!.Value);
                    result.IsSuccess = true;
                    result.HasData = true;

                    break;

                case HttpStatusCode.BadRequest:
                    result.IsSuccess = false;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;

                default:
                    result.IsSuccess = false;
                    result.HasData = false;
                    break;
            }

            return result;
        }

        public async Task<ApiResponse<Tvm>> DeleteAsync<Tdto, Tvm>(string uriPath)
        {
            var requestUri = $"{ApiClient.Client.BaseAddress}/{uriPath}";

            //Add Authentication Token to Header Request if exist
            AddBearerTokenInRequestHeader();

            // Send the request and get the response.
            var responseMessage = await ApiClient.Client.DeleteAsync(requestUri);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            //result of function
            var result = new ApiResponse<Tvm>();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.OK:

                    // Deserialize string To Object
                    var commandResponseDto = JsonConvert.DeserializeObject<Result<Tdto>>(responseContent);

                    //Convert List<UserDto> to List<UserViewModel> powered by autoMapper
                    result.Data = Mapper.Map<Tvm>(commandResponseDto!.Value);
                    result.IsSuccess = true;
                    result.HasData = true;

                    break;

                case HttpStatusCode.NoContent:

                    // Deserialize string To Object
                    var responseDto = JsonConvert.DeserializeObject<Result<Tdto>>(responseContent);

                    //Convert List<UserDto> to List<UserViewModel> powered by autoMapper
                    result.Data = Mapper.Map<Tvm>(responseDto!.Value);
                    result.IsSuccess = true;
                    result.HasData = true;

                    break;

                case HttpStatusCode.BadRequest:
                    result.IsSuccess = false;
                    result.HasData = false;
                    result.Message = responseContent;
                    break;

                default:
                    result.IsSuccess = false;
                    result.HasData = false;
                    break;
            }

            return result;
        }

        #endregion

    }
}
