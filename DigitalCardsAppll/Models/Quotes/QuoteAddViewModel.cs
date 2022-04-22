using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Quotes
{
    public class QuoteAddViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "The field Author must have a minimum length of 10.", MinimumLength = 10)]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "The field Year must have a minimum length of 3.", MinimumLength = 3)]
        public string Year { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The field Genre must have a minimum length of 5.", MinimumLength = 5)]
        public string Genre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The field Description must have a minimum length of 10.", MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field QNumber must have a minimum length of 5.", MinimumLength = 5)]
        [Display(Name = "Code")]
        public string QNumber { get; set; }
    }
}
