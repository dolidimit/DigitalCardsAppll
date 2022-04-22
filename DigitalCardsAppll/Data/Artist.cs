using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCardsAppll.Data
{
    public class Artist
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Url]
        public string SImageUrl { get; set; }
    }
}
