using ClinicManagerMAUI.Models.DTOs.DoctorProfile;
using ClinicManagerMAUI.Models.DTOs.Generic;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for managing doctor profiles.  
    /// </summary>
    internal interface IDoctorProfileService
    {
        /// <summary>
        /// Creates a new doctor profile.
        /// </summary>
        /// <param name="createDoctorProfileDto"></param>
        /// <returns> an <see cref="ApiResponse{DoctorProfileDto}"/> containing the newly created doctor profile's details.</returns>
        Task<ApiResponse<DoctorProfileDto>> CreateDoctorProfile(AddDoctorProfileDto createDoctorProfileDto);

        /// <summary>
        /// Deletes a doctor profile by its unique identifier.
        /// </summary>
        /// <param name="doctorProfileId"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> indicating the result of the deletion operation, where T is <c>object</c>.</returns>
        Task<ApiResponse<object>> DeleteDoctorProfile(int doctorProfileId);

        /// <summary>
        /// Retrieves a doctor profile by its unique identifier.
        /// </summary>
        /// <param name="doctorProfileId"></param>
        /// <returns> An <see cref="ApiResponse{DoctorProfileDto}"/> containing the doctor profile's details if found.</returns>
        Task<ApiResponse<DoctorProfileDto>> GetDoctorProfileById(int doctorProfileId);

        /// <summary>
        /// Retrieves a paginated list of doctor profiles based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> An <see cref="ApiResponse{T}"/> containing a paginated list of doctor profiles, where T is <c>PagedResult&lt;DoctorProfileDto&gt;</c>.</returns>
        Task<ApiResponse<PagedResult<DoctorProfileDto>>> GetDoctorProfiles(QueryDoctorProfileParameters queryParameters);

        /// <summary>
        /// Updates an existing doctor profile.
        /// </summary>
        /// <param name="doctorProfileId"></param>
        /// <param name="updateDoctorProfileDto"></param>
        /// <returns> an <see cref="ApiResponse{DoctorProfileDto}"/> containing the updated doctor profile's details.</returns>
        Task<ApiResponse<DoctorProfileDto>> UpdateDoctorProfile(int doctorProfileId, UpdateDoctorProfileDto updateDoctorProfileDto);
    }
}