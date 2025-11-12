using ClinicManagerMAUI.Constants;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagerMAUI.Models.DTOs.PatientAllergy
{
    public class AddPatientAllergyDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int AllergyId { get; set; }

        public SeverityAllergy Severity { get; set; } = SeverityAllergy.Mild;

        public string Notes { get; set; } = string.Empty;
    }
}