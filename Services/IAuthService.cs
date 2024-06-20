using DemoProject.Models;

namespace DemoProject.Services
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(LoginDto loginDto);
    }
}