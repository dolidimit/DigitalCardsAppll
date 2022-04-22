using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCardsAppll.Data
{
    public class Sticker
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MaxLength(20)]
        public string Topic { get; set; }

        [Required]
        [MaxLength(30)]
        public string ArtistName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Size { get; set; }

        [Required]
        public string SNumber { get; set; }
    }
}
