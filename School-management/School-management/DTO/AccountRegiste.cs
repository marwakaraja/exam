using System.ComponentModel.DataAnnotations;

namespace School_management.DTO
{
    public class AccountRegiste
    {



        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]

        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
