using ClinicManagerMAUI.Constants;
using ClinicManagerMAUI.Models.DTOs.Allergy;
using ClinicManagerMAUI.Models.DTOs.Patient;

namespace ClinicManagerMAUI.Models.DTOs.PatientAllergy
{
    public class PatientAllergyDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public PatientDto? Patient { get; set; }

        public int AllergyId { get; set; }
        public AllergyDto? Allergy { get; set; }

        public SeverityAllergy Severity { get; set; } = SeverityAllergy.Mild;
        public DateTime DiagnosedAt { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; } = string.Empty;
    }
}