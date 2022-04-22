using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Artists
{
    public class ArtistAddViewModel
    {

        [Required]
        [StringLength(30, ErrorMessage = "The field Full Name must be a string with a minimum length of 10.", MinimumLength = 10)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [Required]
        [Url]
        [Display(Name = "Sticker's URL")]
        public string SImageUrl { get; set; }


    }
}
