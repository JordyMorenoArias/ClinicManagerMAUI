using ClinicManagerMAUI.Models.DTOs.Auth;
using ClinicManagerMAUI.Models.DTOs.User;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for handling authentication-related operations.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiService;

        public AuthService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        /// <summary>
        /// Logs in a user with the provided login details.
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns> Logged in user details along with authentication token. </returns>
        public async Task<AuthResponseDto?> Login(UserLoginDto userLoginDto)
        {
            var response = await _apiService.PostAsync<UserLoginDto, AuthResponseDto>("auth/login", userLoginDto);
            return response;
        }

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns> Registered user details along with authentication token. </returns>
        public async Task<AuthResponseDto?> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _apiService.PostAsync<UserRegisterDto, AuthResponseDto>("auth/register", userRegisterDto);
            return response;
        }
    }
}