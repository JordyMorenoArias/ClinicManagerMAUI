using ClinicManagerMAUI.Models.DTOs.Appointment;
using ClinicManagerMAUI.Models.DTOs.Generic;

namespace ClinicManagerMAUI.Services.Interfaces
{
    /// <summary>
    /// Service for managing appointment-related operations.
    /// </summary>
    internal interface IAppointmentService
    {

        /// <summary>
        /// Creates a new appointment.
        /// </summary>
        /// <param name="newAppointment"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the newly created appointment's details.</returns>
        Task<ApiResponse<AppointmentDto>> CreateAppointment(AddAppointmentDto newAppointment);

        /// <summary>
        /// Deletes an appointment by its unique identifier.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns> an <see cref="ApiResponse{T}"/> indicating the result of the deletion operation, where T is <c>object</c>.</returns>
        Task<ApiResponse<object>> DeleteAppointment(int appointmentId);

        /// <summary>
        /// Retrieves an appointment by its unique identifier.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the appointment's details if found.</returns>
        Task<ApiResponse<AppointmentDto>> GetAppointmentById(int appointmentId);

        /// <summary>
        /// Retrieves an appointment by its unique identifier.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the appointment's details if found.</returns>
        Task<ApiResponse<PagedResult<AppointmentDto>>> GetAppointments(QueryAppointmentParameters queryParameters);

        /// <summary>
        /// Updates an existing appointment's information.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="updatedAppointment"></param>
        /// <returns> an <see cref="ApiResponse{AppointmentDto}"/> containing the updated appointment's details.</returns>
        Task<ApiResponse<AppointmentDto>> UpdateAppointment(int appointmentId, UpdateAppointmentDto updatedAppointment);
    }
}