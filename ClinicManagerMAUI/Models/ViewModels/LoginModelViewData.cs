using System.ComponentModel.DataAnnotations;

namespace TaskManagerMAUI.Models
{
    public class LoginModelViewData
    {
        [Required]
        public string User { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}