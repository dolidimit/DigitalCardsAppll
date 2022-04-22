using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Stickers
{
    public class StickerAddViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The field Title must have a minimum length of 5.", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The field Topic must have a minimum length of 5.", MinimumLength = 5)]
        public string Topic { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The field Artist must have a minimum length of 10.", MinimumLength = 10)]
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The field Size must have a minimum length of 5.", MinimumLength = 5)]
        public string Size { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field Code must have a minimum length of 5.", MinimumLength = 5)]
        [Display(Name = "Code")]
        public string SNumber { get; set; }
    }
}
