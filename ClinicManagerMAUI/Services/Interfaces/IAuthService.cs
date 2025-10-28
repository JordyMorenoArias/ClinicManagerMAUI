using ClinicManagerMAUI.Models.DTOs.Auth;
using ClinicManagerMAUI.Models.DTOs.User;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for handling authentication-related operations.
    /// </summary>
    public interface IAuthService
    {
        /// Logs in a user with the provided login details.
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns> Logged in user details along with authentication token. </returns>
        Task<AuthResponseDto?> Login(UserLoginDto userLoginDto);

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns> Registered user details along with authentication token. </returns>
        Task<AuthResponseDto?> Register(UserRegisterDto userRegisterDto);
    }
}