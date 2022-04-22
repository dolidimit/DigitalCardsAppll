using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Users
{
    public class UserRegisterFormModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email must be valid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal")]
        public string ConfirmPassword { get; set; }
    }
}
