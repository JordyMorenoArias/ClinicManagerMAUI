using ClinicManagerMAUI.Constants;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagerMAUI.Models.DTOs.User
{
    public class UserAuthenticatedDto
    {
        [Required]
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; }
    }
}
