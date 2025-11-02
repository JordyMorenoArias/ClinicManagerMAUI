using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.MedicalRecord;

namespace ClinicManagerMAUI.Services.Interfaces
{
    internal interface IMedicalRecordService
    {
        /// <summary>
        /// Creates a new medical record.
        /// </summary>
        /// <param name="newMedicalRecord"></param>
        /// <returns> an <see cref="ApiResponse{MedicalRecordDto}"/> containing the newly created medical record's details.</returns>
        Task<ApiResponse<MedicalRecordDto>> CreateMedicalRecord(AddMedicalRecordDto newMedicalRecord);

        /// <summary>
        /// Retrieves a medical record by its unique identifier.
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <returns> an <see cref="ApiResponse{MedicalRecordDto}"/> containing the medical record's details if found.</returns>
        Task<ApiResponse<MedicalRecordDto>> GetMedicalRecordById(int medical);

        /// <summary>
        /// Retrieves a paginated list of medical records based on query parameters.
        /// </summary>
        /// <param name="medicalRecordParameters"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> containing a paginated list of medical records that match the criteria, where T is <see cref="PagedResult{MedicalRecordDto}"/>.</returns>
        Task<ApiResponse<PagedResult<MedicalRecordDto>>> GetMedicalRecords(QueryMedicalRecordParameters medicalRecordParameters);

        /// <summary>
        /// Updates an existing medical record.
        /// </summary>
        /// <param name="updatedMedicalRecord"></param>
        /// <returns> an <see cref="ApiResponse{MedicalRecordDto}"/> containing the updated medical record's details.</returns>
        Task<ApiResponse<MedicalRecordDto>> UpdateMedicalRecord(UpdateMedicalRecordDto updatedMedicalRecord);
    }
}