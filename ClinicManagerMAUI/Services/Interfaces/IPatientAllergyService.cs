using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.PatientAllergy;

namespace ClinicManagerMAUI.Services.Interfaces
{
    internal interface IPatientAllergyService
    {
        Task<ApiResponse<PatientAllergyDto>> CreatePatientAllergy(AddPatientAllergyDto addPatientAllergyDto);
        Task<ApiResponse<object>> DeletePatientAllergy(int patientAllergyId);
        Task<ApiResponse<PagedResult<PatientAllergyDto>>> GetPatientAllergies(QueryPatientAllergyParameters queryParameters);
        Task<ApiResponse<PatientAllergyDto>> GetPatientAllergyById(int patientAllergyId);
        Task<ApiResponse<PatientAllergyDto>> UpdatePatientAllergy(int patientAllergyId, UpdatePatientAllergyDto updatePatientAllergyDto);
    }
}