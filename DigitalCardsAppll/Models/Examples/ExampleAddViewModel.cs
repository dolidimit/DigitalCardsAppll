using System.ComponentModel.DataAnnotations;

namespace DigitalCardsAppll.Models.Examples
{
    public class ExampleAddViewModel
    {
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Description { get; set; }

    }
}
