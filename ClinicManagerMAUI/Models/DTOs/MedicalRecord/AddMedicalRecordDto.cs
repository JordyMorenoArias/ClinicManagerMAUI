using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagerMAUI.Models.DTOs.MedicalRecord
{
    public class AddMedicalRecordDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required, MaxLength(500)]
        public string Diagnosis { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Treatment { get; set; } = string.Empty;
    }
}
