using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Authors
{
    public class AuthorAddViewModel
    {

        [Required]
        [StringLength(20, ErrorMessage = "The field Full Name must have a minimum length of 10.", MinimumLength = 10)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "The field Quote must have a minimum length of 10.", MinimumLength = 10)]
        [Display(Name = "Quote")]
        public string PQuote { get; set; }

    }
}
