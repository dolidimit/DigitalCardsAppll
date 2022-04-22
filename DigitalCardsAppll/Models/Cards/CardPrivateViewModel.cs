using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCardsAppll.Models.Cards
{
    public class CardPrivateViewModel
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Receiver { get; set; }

        public string Model { get; set; }

        public string SNumber { get; set; }

        public string QNumber { get; set; }

        public bool PublicView { get; set; }

    }
}
