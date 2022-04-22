using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Users
{
    public class UserLoginFormModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email must be valid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password is not valid!")]
        public string Password { get; set; }
    }
}
