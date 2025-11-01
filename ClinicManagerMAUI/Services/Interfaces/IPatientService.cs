using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.Patient;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for managing patient-related operations.
    /// </summary>
    internal interface IPatientService
    {
        /// <summary>
        /// Creates a new patient.
        /// </summary>
        /// <param name="newPatient"></param>
        /// <returns> an <see cref="ApiResponse{PatientDto}"/> containing the newly created patient's details.</returns>
        Task<ApiResponse<PatientDto>> CreatePatient(AddPatientDto newPatient);

        /// <summary>
        /// Deletes a patient by their unique identifier.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> indicating the result of the deletion operation, where T is <c>object</c>.</retur
        Task<ApiResponse<object>> DeletePatient(int patientId);

        /// <summary>
        /// Retrieves a patient by their unique identifier.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns> an <see cref="ApiResponse{PatientDto}"/> containing the patient's details if found.</returns>
        Task<ApiResponse<PatientDto>> GetPatientById(int patientId);

        /// <summary>
        /// Retrieves a paginated list of patients based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> containing a paginated list of patients that match the criteria, where T is <see cref="PagedResult{PatientDto}"/>.</returns>
        Task<ApiResponse<PagedResult<PatientDto>>> GetPatients(QueryPatientParameters queryParameters);

        /// <summary>
        /// Updates an existing patient's information.
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="updatedPatient"></param>
        /// <returns> an <see cref="ApiResponse{PatientDto}"/> containing the updated patient's details.</returns>
        Task<ApiResponse<PatientDto>> UpdatePatient(int patientId, UpdatePatientDto updatedPatient);
    }
}