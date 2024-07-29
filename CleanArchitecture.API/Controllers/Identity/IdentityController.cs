using CleanArchitecture.API.Attributes;
using CleanArchitecture.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using CleanArchitecture.Application.Interfaces.Identity;

namespace CleanArchitecture.API.Controllers.Identity
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService, ILogger<IdentityController> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        [HttpPost("login")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _identityService.LoginAsync(loginRequest);

            if (loginResponse.IsSuccess)
            {
                _logger.LogInformation($"User ({loginRequest.UserName}) logged successfully");
                return Ok(loginResponse);
            }

            _logger.LogInformation($"User ({loginRequest.UserName}) failed login");

            return BadRequest(loginResponse.Errors);
        }

        
        [HttpPost("register")]
        [ResponseType(StatusCodes.Status200OK)]
        [ResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest)
        {
            var registerResponse = await _identityService.RegisterAsync(registerRequest);

            if (registerResponse.IsSuccess)
            {
                return Ok(registerResponse);
            }

            return BadRequest(registerResponse.Errors);
        }
        
    }
    
}
