using Auth_WebAPI.Entities;
using Auth_WebAPI.Model;

namespace Auth_WebAPI.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);
        Task<string?> LoginAsync(UserDto request);
    }
}
