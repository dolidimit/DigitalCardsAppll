using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCardsAppll.Data
{
    public class Card
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(20)]
        public string Destination { get; set; }

        [MaxLength(30)]
        public string Receiver { get; set; }

        [MaxLength(10)]
        public string Model { get; set; }

        [MaxLength(30)]
        public string SNumber { get; set; }

        [MaxLength(30)]
        public string QNumber { get; set; }

        public bool PublicView { get; set; }


    }
}
