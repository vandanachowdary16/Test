using System.ComponentModel.DataAnnotations;

namespace ePizzaHub.UI.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; } = default!;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long.")]
        [MaxLength(15, ErrorMessage = "Password cannot exceed 15 characters.")]
        public string Password { get; set; } = default!;
    }
}
