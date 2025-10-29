using ClinicManagerMAUI.Models.DTOs.Auth;
using ClinicManagerMAUI.Models.DTOs.Generic;
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
        private readonly ISecureStorageService _secureStorageService;

        public AuthService(IApiService apiService, ISecureStorageService tokenService)
        {
            this._apiService = apiService;
            this._secureStorageService = tokenService;
        }

        /// <summary>
        /// Logs in a user with the provided login details.
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns> Logged in user details along with authentication token. </returns>
        public async Task<ApiResponse<AuthResponseDto>> Login(UserLoginDto userLoginDto)
        {
            var response = await _apiService.PostAsync<UserLoginDto, AuthResponseDto>("auth/login", userLoginDto);

            var token = response.Data?.Token;

            if (token is not null)
            {
                await _secureStorageService.SaveAsync("auth_token", token);
            }

            return response;
        }

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns> Registered user details along with authentication token. </returns>
        public async Task<ApiResponse<AuthResponseDto>> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _apiService.PostAsync<UserRegisterDto, AuthResponseDto>("auth/register", userRegisterDto);
            return response;
        }
    }
}