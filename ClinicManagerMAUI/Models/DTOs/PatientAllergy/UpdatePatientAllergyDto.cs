using ClinicManagerMAUI.Constants;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagerMAUI.Models.DTOs.PatientAllergy
{
    public class UpdatePatientAllergyDto
    {
        public SeverityAllergy Severity { get; set; } = SeverityAllergy.Mild;

        public string Notes { get; set; } = string.Empty;
    }
}