using DemoProject.Data;
using DemoProject.Models;

namespace DemoProject.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(LoginDto loginDto)
        {
            return await _userRepository.GetUserByCredentialsAsync(loginDto.Username, loginDto.Password);
        }
    }
}