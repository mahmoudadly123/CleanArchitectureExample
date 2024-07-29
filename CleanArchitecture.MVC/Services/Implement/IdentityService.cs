using System.Security.Claims;
using AutoMapper;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanArchitecture.MVC.Services.Implement
{
    public class IdentityService: ApiService,IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IMapper mapper, IApiClient apiClient, ILocalStorageService localStorage,IHttpContextAccessor httpContextAccessor) : base(mapper, apiClient, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> Login(string username, string password,string securityStamp)
        {

            try
            {
                
                //Try To Login using Api and Identity Service
                var data = new LoginRequest
                {
                    UserName = username,
                    UserPassword = password,
                    SecurityStamp = securityStamp
                };

                var serviceResult = await PostAsync<LoginResponse>("Identity/login", data);

                var loginResponse = serviceResult.Data;

                
                //if login failed ----------------------


                if (serviceResult.IsSuccess==false || string.IsNullOrEmpty(loginResponse.UserToken))
                    return false;


                //if login Success ---------------------

                //create user Principal that contain its claims
                var claimsIdentity = new ClaimsIdentity(loginResponse.UserClaims, CookieAuthenticationDefaults.AuthenticationScheme,"name","role");
                
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                //sign-in user Principal inside httpContext
                await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                

                //store user Token inside LocalStorage
                LocalStorage.SetStorageValue("token", loginResponse.UserToken);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            LocalStorage.ClearStorage("token");
        }

        public async Task<bool> Register(string username, string password, string email)
        {
            try
            {

                //Try To Register using Api and Identity Service
                var data = new RegisterRequest
                {
                    UserName = username,
                    UserPassword = password,
                    Email = email
                };

                var serviceResult = await PostAsync<RegisterResponse>("Identity/register", data);

                var registerResponse = serviceResult.Data;

                //if register failed ----------------------
                if (registerResponse.IsSuccess == false && string.IsNullOrEmpty(registerResponse.UserId))
                    return false;


                //if register Success ---------------------
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
