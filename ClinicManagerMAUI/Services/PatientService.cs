using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.Patient;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for managing patient-related operations.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IApiService apiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService"/> class.
        /// </summary>
        /// <param name="apiService"></param>
        public PatientService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        /// <summary>
        /// Retrieves a patient by their unique identifier.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns> an <see cref="ApiResponse{PatientDto}"/> containing the patient's details if found.</returns>
        public async Task<ApiResponse<PatientDto>> GetPatientById(int patientId)
        {
            return await apiService.GetAsync<PatientDto>($"patient/{patientId}");
        }

        /// <summary>
        /// Retrieves a paginated list of patients based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> containing a paginated list of patients that match the criteria, where T is <see cref="PagedResult{PatientDto}"/>.</returns>
        public async Task<ApiResponse<PagedResult<PatientDto>>> GetPatients(QueryPatientParameters queryParameters)
        {
            var queryString = $"?Page={queryParameters.Page}&pageSize={queryParameters.PageSize}";

            if (queryParameters.DateOfBirth.HasValue)
                queryString += $"&DateOfBirth={queryParameters.DateOfBirth.Value:yyyy-MM-dd}";

            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
                queryString += $"&SearchTerm={Uri.EscapeDataString(queryParameters.SearchTerm)}";

            var response = await apiService.GetAsync<PagedResult<PatientDto>>($"patient/{queryString}");
            return response;
        }

        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="newPatient"></param>
        /// <returns> an <see cref="ApiResponse{PatientDto}"/> containing the newly created patient's details.</returns>
        public async Task<ApiResponse<PatientDto>> CreatePatient(AddPatientDto newPatient)
        {
            return await apiService.PostAsync<AddPatientDto, PatientDto>("patient", newPatient);
        }

        /// <summary>
        /// Updates an existing patient's information.
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="updatedPatient"></param>
        /// <returns> an <see cref="ApiResponse{PatientDto}"/> containing the updated patient's details.</returns>
        public async Task<ApiResponse<PatientDto>> UpdatePatient(int patientId, UpdatePatientDto updatedPatient)
        {
            return await apiService.PutAsync<UpdatePatientDto, PatientDto>($"patient/{patientId}", updatedPatient);
        }

        /// <summary>
        /// Deletes a patient by their unique identifier.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> indicating the result of the deletion operation, where T is <c>object</c>.</returns>
        public async Task<ApiResponse<object>> DeletePatient(int patientId)
        {
            return await apiService.DeleteAsync($"patient/{patientId}");
        }
    }
}
