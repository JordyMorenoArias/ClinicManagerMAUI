using ClinicManagerMAUI.Models.DTOs.DoctorProfile;
using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for managing doctor profiles.
    /// </summary>
    public class DoctorProfileService : IDoctorProfileService
    {
        private readonly IApiService apiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorProfileService"/> class.
        /// </summary>
        /// <param name="apiService"></param>
        public DoctorProfileService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        /// <summary>
        /// Retrieves a doctor profile by its unique identifier.
        /// </summary>
        /// <param name="doctorProfileId"></param>
        /// <returns> An <see cref="ApiResponse{DoctorProfileDto}"/> containing the doctor profile's details if found.</returns>
        public async Task<ApiResponse<DoctorProfileDto>> GetDoctorProfileById(int doctorProfileId)
        {
            return await apiService.GetAsync<DoctorProfileDto>($"doctorprofile/{doctorProfileId}");
        }

        /// <summary>
        /// Retrieves a paginated list of doctor profiles based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> An <see cref="ApiResponse{T}"/> containing a paginated list of doctor profiles, where T is <c>PagedResult&lt;DoctorProfileDto&gt;</c>.</returns>
        public async Task<ApiResponse<PagedResult<DoctorProfileDto>>> GetDoctorProfiles(QueryDoctorProfileParameters queryParameters)
        {
            var queryString = $"?Page={queryParameters.Page}&pageSize={queryParameters.PageSize}";

            if (queryParameters.DoctorId.HasValue)
                queryString += $"&DoctorId={queryParameters.DoctorId.Value}";

            var response = await apiService.GetAsync<PagedResult<DoctorProfileDto>>($"doctorprofile/{queryString}");
            return response;
        }

        /// <summary>
        /// Creates a new doctor profile.
        /// </summary>
        /// <param name="createDoctorProfileDto"></param>
        /// <returns> an <see cref="ApiResponse{DoctorProfileDto}"/> containing the newly created doctor profile's details.</returns>
        public async Task<ApiResponse<DoctorProfileDto>> CreateDoctorProfile(AddDoctorProfileDto createDoctorProfileDto)
        {
            return await apiService.PostAsync<AddDoctorProfileDto, DoctorProfileDto>("doctorprofile", createDoctorProfileDto);
        }

        /// <summary>
        /// Updates an existing doctor profile.
        /// </summary>
        /// <param name="doctorProfileId"></param>
        /// <param name="updateDoctorProfileDto"></param>
        /// <returns> an <see cref="ApiResponse{DoctorProfileDto}"/> containing the updated doctor profile's details.</returns>
        public async Task<ApiResponse<DoctorProfileDto>> UpdateDoctorProfile(int doctorProfileId, UpdateDoctorProfileDto updateDoctorProfileDto)
        {
            return await apiService.PutAsync<UpdateDoctorProfileDto, DoctorProfileDto>($"doctorprofile/{doctorProfileId}", updateDoctorProfileDto);
        }

        /// <summary>
        /// Deletes a doctor profile by its unique identifier.
        /// </summary>
        /// <param name="doctorProfileId"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> indicating the result of the deletion operation, where T is <c>object</c>.</returns>
        public async Task<ApiResponse<object>> DeleteDoctorProfile(int doctorProfileId)
        {
            return await apiService.DeleteAsync($"doctorprofile/{doctorProfileId}");
        }
    }
}