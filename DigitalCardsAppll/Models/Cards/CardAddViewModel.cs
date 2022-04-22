using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Cards
{
    public class CardAddViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The field Destination must have a minimum length of 10.", MinimumLength = 10)]
        public string Destination { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The field Title must have a minimum length of 5.", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field Receiver must have a minimum length of 10.", MinimumLength = 10)]
        public string Receiver { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The field Model must have a minimum length of 10.", MinimumLength = 5)]
        [MaxLength(10)]
        public string Model { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field SNumber must have a minimum length of 5.", MinimumLength = 5)]
        [Display(Name = "Sticker Code:")]
        public string SNumber { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field QNumber must have a minimum length of 5.", MinimumLength = 5)]
        [Display(Name = "Quote Code:")]
        public string QNumber { get; set; }

        [Required]
        [Display(Name = "Public View")]
        public bool PublicView { get; set; }
    }
}
