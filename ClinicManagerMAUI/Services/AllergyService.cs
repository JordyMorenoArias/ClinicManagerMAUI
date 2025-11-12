using ClinicManagerMAUI.Models.DTOs.Allergy;
using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly IApiService _apiService;

        public AllergyService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        public async Task<ApiResponse<AllergyDto>> GetAllergyById(int allergy)
        {
            return await _apiService.GetAsync<AllergyDto>($"allergy/{allergy}");
        }

        public async Task<ApiResponse<PagedResult<AllergyDto>>> GetAllergies(QueryAllergyParameters queryParameters)
        {
            var queryString = $"?Page={queryParameters.Page}&pageSize={queryParameters.PageSize}";

            if (!string.IsNullOrWhiteSpace(queryParameters.SearchTerm))
                queryString += $"&SearchTerm={queryParameters.SearchTerm}";

            var response = await _apiService.GetAsync<PagedResult<AllergyDto>>($"allergy/{queryString}");
            return response;
        }

        public async Task<ApiResponse<AllergyDto>> CreateAllergy(CreateAllergyDto createAllergyDto)
        {
            return await _apiService.PostAsync<CreateAllergyDto, AllergyDto>("Allergy", createAllergyDto);
        }

        public async Task<ApiResponse<AllergyDto>> UpdateAllergy(int allergyId, UpdateAllergyDto updateAllergyDto)
        {
            return await _apiService.PutAsync<UpdateAllergyDto, AllergyDto>($"allergy/{allergyId}", updateAllergyDto);
        }

        public async Task<ApiResponse<object>> DeleteAllergy(int allergyId)
        {
            return await _apiService.DeleteAsync($"allergy/{allergyId}");
        }
    }
}