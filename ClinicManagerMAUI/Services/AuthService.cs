using ClinicManagerMAUI.Constants;
using ClinicManagerMAUI.Models.DTOs.Auth;
using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.User;
using ClinicManagerMAUI.Services.Interfaces;
using System.Text;
using System.Text.Json;

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
        /// Decodes the stored JWT token to extract user information.
        /// </summary>
        /// <returns> a <see cref="UserAuthenticatedDto"/> containing the authenticated user's details.</returns>
        public async Task<UserAuthenticatedDto> DecodeAsync()
        {
            var token = await _secureStorageService.GetAsync("auth_token");

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("No se encontró el token de autenticación");

            var parts = token.Split('.');

            if (parts.Length != 3)
                throw new Exception("Token inválido");

            // Decodificar payload (parte 2)
            var payload = parts[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var json = Encoding.UTF8.GetString(jsonBytes);

            // Deserializar el payload
            var claims = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            if (claims is null)
                throw new Exception("No se pudieron obtener los claims del token");

            var user = new UserAuthenticatedDto();

            if (claims.TryGetValue("Role", out var roleValue))
            {
                if (Enum.TryParse<UserRole>(roleValue.ToString(), true, out var parsedRole))
                    user.Role = parsedRole;
            }

            if (claims.TryGetValue("Id", out var idValue))
            {
                if (int.TryParse(idValue.ToString(), out var parsedId))
                    user.Id = parsedId;
            }

            if (claims.TryGetValue("Email", out var emailValue))
                user.Email = emailValue?.ToString() ?? string.Empty;

            return user;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            base64 = base64.Replace('-', '+').Replace('_', '/');
            return Convert.FromBase64String(base64);
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