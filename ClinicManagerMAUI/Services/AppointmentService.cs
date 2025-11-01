using ClinicManagerMAUI.Models.DTOs.Appointment;
using ClinicManagerMAUI.Models.DTOs.Generic;
using ClinicManagerMAUI.Services.Interfaces;
using System.Net.Http.Headers;

namespace ClinicManagerMAUI.Services
{
    /// <summary>
    /// Service for managing appointment-related operations.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IApiService _apiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentService"/> class.
        /// </summary>
        /// <param name="apiService"></param>
        public AppointmentService(IApiService apiService)
        {
            this._apiService = apiService;
        }

        /// <summary>
        /// Retrieves an appointment by its unique identifier.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the appointment's details if found.</returns>
        public async Task<ApiResponse<AppointmentDto>> GetAppointmentById(int appointmentId)
        {
            return await _apiService.GetAsync<AppointmentDto>($"appointment{appointmentId}");
        }

        /// <summary>
        /// Retrieves a paginated list of appointments based on query parameters.
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> containing a paginated list of appointments that match the criteria, where T is <see cref="PagedResult{AppointmentDto}"/>.</returns>
        public async Task<ApiResponse<PagedResult<AppointmentDto>>> GetAppointments(QueryAppointmentParameters queryParameters)
        {
            var queryString = $"?Page={queryParameters.Page}&pageSize={queryParameters.PageSize}";

            if (queryParameters.StartDateFilter.HasValue)
                queryString += $"&StartDateFilter={queryParameters.StartDateFilter.Value:yyyy-MM-dd}";

            if (queryParameters.EndDateFilter.HasValue)
                queryString += $"&EndDateFilter={queryParameters.EndDateFilter.Value:yyyy-MM-dd}";

            if (queryParameters.DoctorId.HasValue)
                queryString += $"&DoctorId={queryParameters.DoctorId.Value}";

            if (queryParameters.PatientId.HasValue)
                queryString += $"&PatientId={queryParameters.PatientId.Value}";

            if (queryParameters.Status.HasValue)
                queryString += $"&Status={queryParameters.Status.Value}";

            if (queryParameters.SortBy.HasValue)
                queryString += $"&SortBy={queryParameters.SortBy.Value}";

            var response = await _apiService.GetAsync<PagedResult<AppointmentDto>>($"appointment/{queryString}");
            return response;
        }

        /// <summary>
        /// Creates a new appointment.
        /// </summary>
        /// <param name="newAppointment"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the newly created appointment's details.</returns>
        public async Task<ApiResponse<AppointmentDto>> CreateAppointment(AddAppointmentDto newAppointment)
        {
            return await _apiService.PostAsync<AddAppointmentDto, AppointmentDto>("appointment", newAppointment);
        }

        /// <summary>
        /// Updates an existing appointment's information.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="updatedAppointment"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the updated appointment's details.</returns>
        public async Task<ApiResponse<AppointmentDto>> UpdateAppointment(int appointmentId, UpdateAppointmentDto updatedAppointment)
        {
            return await _apiService.PutAsync<UpdateAppointmentDto, AppointmentDto>($"appointment/{appointmentId}", updatedAppointment);
        }

        /// <summary>
        /// Deletes an appointment by its unique identifier.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> indicating the result of the deletion operation, where T is <c>object</c>.</returns>
        public async Task<ApiResponse<object>> DeleteAppointment(int appointmentId)
        {
            return await _apiService.DeleteAsync($"appointments/{appointmentId}");
        }
    }
}