using System.ComponentModel.DataAnnotations;

namespace School_management.DTO
{
    public class AccountLogin
    {
        [Required]

        public string Email { get; set; } = string.Empty;
        [Required]

        public string Password { get; set; } = string.Empty;
    }
}
