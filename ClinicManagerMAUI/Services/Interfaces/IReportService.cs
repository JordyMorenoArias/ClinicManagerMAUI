using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Models.DTOs.Report;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for generating reports
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Generates a patient report based on the provided query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> api response containing the report summary data</returns>
        Task<ApiResponse<ReportSummaryDto>> GeneratePatientReportAsync(QueryReportParameters queryParameters);
    }
}