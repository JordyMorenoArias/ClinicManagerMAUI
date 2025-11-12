using ClinicManagerMAUI.Constants;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagerMAUI.Models.DTOs.Appointment
{
    public class UpdateAppointmentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(300)]
        public string Reason { get; set; } = string.Empty;

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
    }
}
