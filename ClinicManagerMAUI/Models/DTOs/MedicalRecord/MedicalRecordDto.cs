using ClinicManagerMAUI.Models.DTOs.Patient;
using ClinicManagerMAUI.Models.DTOs.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagerMAUI.Models.DTOs.MedicalRecord
{
    public class MedicalRecordDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }
        public PatientDto Patient { get; set; } = new PatientDto();

        [Required]
        public int? DoctorId { get; set; }
        public UserDto Doctor { get; set; } = null!;

        [Required, MaxLength(500)]
        public string Diagnosis { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Treatment { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}