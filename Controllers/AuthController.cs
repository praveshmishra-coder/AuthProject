using Auth_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Auth_WebAPI.Model;
using Auth_WebAPI.Services;
using Microsoft.AspNetCore.Authorization; 

namespace Auth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<User?>> Register(UserDto request)
        {
            var user = await service.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("User already exists.");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var token = await service.LoginAsync(request);
            if (token is null)
            {
                return BadRequest("Invalid username or password.");
            }
            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var token = await service.RefreshTokenAsync(request);
            if (token is null)
            {
                return BadRequest("Invalid / Expired Token");
            }
            return Ok(token);
        }

        [HttpGet("Auth-endpoint")]
        [Authorize]
        public ActionResult<string> GetSecret()
        {
            return "You are authorized to access this endpoint.";
        }

        [HttpGet("Admin-endpoint")]
        [Authorize (Roles ="Admin")]
        public ActionResult<string> AdminCheck()
        {
            return "You are admin";
        }


    } 

}
