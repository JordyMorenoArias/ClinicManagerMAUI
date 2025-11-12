using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.PatientAllergy;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    public class PatientAllergyService : IPatientAllergyService
    {
        private readonly IApiService apiService;

        public PatientAllergyService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<ApiResponse<PatientAllergyDto>> GetPatientAllergyById(int patientAllergyId)
        {
            return await apiService.GetAsync<PatientAllergyDto>($"patientallergy/{patientAllergyId}");
        }

        public async Task<ApiResponse<PagedResult<PatientAllergyDto>>> GetPatientAllergies(QueryPatientAllergyParameters queryParameters)
        {
            var queryString = $"?Page={queryParameters.Page}&pageSize={queryParameters.PageSize}";

            if (queryParameters.PatientId.HasValue)
                queryString += $"&PatientId={queryParameters.PatientId.Value}";

            if (queryParameters.AllergyId.HasValue)
                queryString += $"&AllergyId={queryParameters.AllergyId.Value}";

            var response = await apiService.GetAsync<PagedResult<PatientAllergyDto>>($"patientallergy/{queryString}");
            return response;
        }

        public async Task<ApiResponse<PatientAllergyDto>> CreatePatientAllergy(AddPatientAllergyDto addPatientAllergyDto)
        {
            return await apiService.PostAsync<AddPatientAllergyDto, PatientAllergyDto>("patientallergy", addPatientAllergyDto);
        }

        public async Task<ApiResponse<PatientAllergyDto>> UpdatePatientAllergy(int patientAllergyId, UpdatePatientAllergyDto updatePatientAllergyDto)
        {
            return await apiService.PutAsync<UpdatePatientAllergyDto, PatientAllergyDto>($"patientallergy/{patientAllergyId}", updatePatientAllergyDto);
        }

        public async Task<ApiResponse<object>> DeletePatientAllergy(int patientAllergyId)
        {
            return await apiService.DeleteAsync($"patientallergy/{patientAllergyId}");
        }
    }
}