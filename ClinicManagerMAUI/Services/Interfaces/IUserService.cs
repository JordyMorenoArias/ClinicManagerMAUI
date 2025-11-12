using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.User;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for managing user-related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Changes the password of a user.
        /// </summary>
        /// <param name="changePasswordDto"></param>
        /// <returns> An <see cref="ApiResponse{UserDto}"/> containing the user's details after the password change.</returns>
        Task<ApiResponse<UserDto>> ChangePassword(UserChangePasswordDto changePasswordDto);

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>An <see cref="ApiResponse{UserDto}"/> containing the user's details if found.</returns>
        Task<ApiResponse<UserDto>> GetUserById(int userId);

        /// <summary>
        /// Retrieves a paginated list of users based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a paginated list of users that match the criteria, where <c>T</c> is <see cref="PagedResult{UserDto}"/>.</returns>
        Task<ApiResponse<PagedResult<UserDto>>> GetUsers(QueryUserParameters queryParameters);

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updatedUser"></param>
        /// <returns>An <see cref="ApiResponse{UserDto}"/> containing the updated user's details.</returns>
        Task<ApiResponse<UserDto>> UpdateUser(int userId, UserUpdateDto updatedUser);
    }
}