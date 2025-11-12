using ClinicManagerMAUI.Models.DTOs.Allergy;
using ClinicManagerMAUI.Models.DTOs.Generic;

namespace ClinicManagerMAUI.Services
{
    public interface IAllergyService
    {
        Task<ApiResponse<AllergyDto>> CreateAllergy(CreateAllergyDto createAllergyDto);
        Task<ApiResponse<object>> DeleteAllergy(int allergyId);
        Task<ApiResponse<PagedResult<AllergyDto>>> GetAllergies(QueryAllergyParameters queryParameters);
        Task<ApiResponse<AllergyDto>> GetAllergyById(int allergy);
        Task<ApiResponse<AllergyDto>> UpdateAllergy(int allergyId, UpdateAllergyDto updateAllergyDto);
    }
}