using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.MedicalRecord;
using ClinicManagerMAUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for managing medical record-related operations.
    /// </summary>
    internal class MedicalRecordService : IMedicalRecordService
    {
        private readonly IApiService _apiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordService"/> class.
        /// </summary>
        /// <param name="apiService"></param>
        public MedicalRecordService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        /// <summary>
        /// Retrieves a medical record by its unique identifier.
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <returns> an <see cref="ApiResponse{MedicalRecordDto}"/> containing the medical record's details if found.</returns>
        public async Task<ApiResponse<MedicalRecordDto>> GetMedicalRecordById(int medicalRecordId)
        {
            return await _apiService.GetAsync<MedicalRecordDto>($"medicalrecord/{medicalRecordId}");
        }

        /// <summary>
        /// Retrieves a paginated list of medical records based on query parameters.
        /// </summary>
        /// <param name="medicalRecordParameters"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> containing a paginated list of medical records that match the criteria, where T is <see cref="PagedResult{MedicalRecordDto}"/>.</returns>
        public async Task<ApiResponse<PagedResult<MedicalRecordDto>>> GetMedicalRecords(QueryMedicalRecordParameters medicalRecordParameters)
        {
            var queryString = $"?Page={medicalRecordParameters.Page}&pageSize={medicalRecordParameters.PageSize}";

            if (medicalRecordParameters.patientId.HasValue)
                queryString += $"&patientId={medicalRecordParameters.patientId.Value}";

            if (medicalRecordParameters.doctorId.HasValue)
                queryString += $"&doctorId={medicalRecordParameters.doctorId.Value}";

            var response = await _apiService.GetAsync<PagedResult<MedicalRecordDto>>($"medicalrecord/{queryString}");
            return response;
        }

        /// <summary>
        /// Creates a new medical record.
        /// </summary>
        /// <param name="newMedicalRecord"></param>
        /// <returns> an <see cref="ApiResponse{MedicalRecordDto}"/> containing the newly created medical record's details.</returns>
        public async Task<ApiResponse<MedicalRecordDto>> CreateMedicalRecord(AddMedicalRecordDto newMedicalRecord)
        {
            return await _apiService.PostAsync<AddMedicalRecordDto, MedicalRecordDto>("medicalrecord", newMedicalRecord);
        }

        /// <summary>
        /// Updates an existing medical record.
        /// </summary>
        /// <param name="updatedMedicalRecord"></param>
        /// <returns> an <see cref="ApiResponse{MedicalRecordDto}"/> containing the updated medical record's details.</returns>
        public async Task<ApiResponse<MedicalRecordDto>> UpdateMedicalRecord(UpdateMedicalRecordDto updatedMedicalRecord)
        {
            return await _apiService.PutAsync<UpdateMedicalRecordDto, MedicalRecordDto>($"medicalrecord/{updatedMedicalRecord.Id}", updatedMedicalRecord);
        }
    }
}