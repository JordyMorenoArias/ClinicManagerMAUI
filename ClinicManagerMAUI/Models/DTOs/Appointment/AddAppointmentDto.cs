using System.ComponentModel.DataAnnotations;

namespace ClinicManagerMAUI.Models.DTOs.Appointment
{
    public class AddAppointmentDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(300)]
        public string Reason { get; set; } = string.Empty;
    }
}
