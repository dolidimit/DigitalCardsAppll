using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCardsAppll.Data
{
    public class Author
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
        [MaxLength(50)]
        public string PQuote { get; set; }
    }
}
