using ClinicManagerMAUI.Models.DTOs.Auth;
using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.User;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for handling authentication-related operations.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Decodes the stored JWT token to extract user information.
        /// </summary>
        /// <returns> a <see cref="UserAuthenticatedDto"/> containing the authenticated user's details.</returns>
        Task<UserAuthenticatedDto> DecodeAsync();

        /// Logs in a user with the provided login details.
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns> Logged in user details along with authentication token. </returns>
        Task<ApiResponse<AuthResponseDto>> Login(UserLoginDto userLoginDto);

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns> Registered user details along with authentication token. </returns>
        Task<ApiResponse<AuthResponseDto>> Register(UserRegisterDto userRegisterDto);
    }
}