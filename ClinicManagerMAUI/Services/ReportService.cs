using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.Report;
using ClinicManagerMAUI.Services.Interfaces;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for generating reports
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly IApiService _apiService;

        /// <summary>
        /// Constructor for ReportService
        /// </summary>
        /// <param name="apiService"></param>
        public ReportService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        /// <summary>
        /// Generates a patient report based on the provided query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> api response containing the report summary data</returns>
        public async Task<ApiResponse<ReportSummaryDto>> GeneratePatientReportAsync(QueryReportParameters queryParameters)
        {
            var endpoint = $"Report/summary?StartDate={queryParameters.StartDate:yyyy-MM-dd}&EndDate={queryParameters.EndDate:yyyy-MM-dd}";
            var response = await _apiService.GetAsync<ReportSummaryDto>(endpoint);
            return response;
        }
    }
}