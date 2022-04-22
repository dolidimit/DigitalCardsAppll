using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCardsAppll.Data
{
    public class Quote
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string AuthorName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(4)]
        public string Year { get; set; }

        [Required]
        [MaxLength(20)]
        public string Genre { get; set; }

        [Required]
        public string QNumber { get; set; }
    }
}
