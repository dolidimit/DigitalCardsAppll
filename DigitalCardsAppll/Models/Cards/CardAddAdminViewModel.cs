using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Cards
{
    public class CardAddAdminViewModel
    {

        [Required]
        [StringLength(20, ErrorMessage = "The field Destination must have a minimum length of 10.", MinimumLength = 10)]
        public string Destination { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

    }
}
