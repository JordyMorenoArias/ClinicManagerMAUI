using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.User;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for managing user-related operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="apiService"></param>
        public UserService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>An <see cref="ApiResponse{UserDto}"/> containing the user's details if found.</returns>
        public async Task<ApiResponse<UserDto>> GetUserById(int userId)
        {
            return await _apiService.GetAsync<UserDto>($"user/{userId}");
        }

        /// <summary>
        /// Retrieves a paginated list of users based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a paginated list of users that match the criteria, where <c>T</c> is <see cref="PagedResult{UserDto}"/>.</returns>
        public async Task<ApiResponse<PagedResult<UserDto>>> GetUsers(QueryUserParameters queryParameters)
        {
            var queryString = $"?Page={queryParameters.Page}&pageSize={queryParameters.PageSize}";

            if (queryParameters.IsActive.HasValue)
                queryString += $"&IsActive={queryParameters.IsActive.Value}";

            if (!string.IsNullOrEmpty(queryParameters.Role))
                queryString += $"&Role={Uri.EscapeDataString(queryParameters.Role)}";

            if (queryParameters.UserRole.HasValue)
                queryString += $"&UserRole={queryParameters.UserRole.Value}";

            if (!string.IsNullOrWhiteSpace(queryParameters.SearchTerm))
                queryString += $"&SearchTerm={queryParameters.SearchTerm}";

            var response = await _apiService.GetAsync<PagedResult<UserDto>>($"user/{queryString}");
            return response;
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="updatedUser"></param>
        /// <returns>An <see cref="ApiResponse{UserDto}"/> containing the updated user's details.</returns>
        public async Task<ApiResponse<UserDto>> UpdateUser(int userId, UserUpdateDto updatedUser)
        {
            return await _apiService.PutAsync<UserUpdateDto, UserDto>($"user/{userId}", updatedUser);
        }

        /// <summary>
        /// Changes the password of a user.
        /// </summary>
        /// <param name="changePasswordDto"></param>
        /// <returns> An <see cref="ApiResponse{UserDto}"/> containing the user's details after the password change.</returns>
        public async Task<ApiResponse<UserDto>> ChangePassword(UserChangePasswordDto changePasswordDto)
        {
            return await _apiService.PutAsync<UserChangePasswordDto, UserDto>("user/change-password", changePasswordDto);
        }
    }
}