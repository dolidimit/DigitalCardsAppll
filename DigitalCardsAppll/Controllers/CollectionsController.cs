using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Artists;
using DigitalCardsAppll.Models.Author;
using DigitalCardsAppll.Models.Cards;
using DigitalCardsAppll.Models.Quotes;
using DigitalCardsAppll.Models.Stickers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly DigitalCardsDbContext data;

        public CollectionsController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdminCards()
        {
            var cards = this.data.Cards
                .Where(c => c.PublicView == true)
                .ToList();

            var cardsl = cards
                .OrderBy(x => x.Id)
                .Select(c => new CardAllAdminViewModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Destination = c.Destination
                })
                .ToList();

            return View(cardsl);

        }

        public IActionResult PublicCards()
        {
            var cards = this.data.Cards
                .ToList();

            var cardsl = cards
                .Where(x => x.PublicView == true)
                .Select(c => new CardAllAdminViewModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Destination = c.Destination
                })
                .ToList();

            return View(cardsl);

        }

        public IActionResult YourCards()
        {
            var cards = this.data.Cards
                .ToList();

            var cardsl = cards
                .Select(c => new CardPrivateViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                    Destination = c.Destination,
                    Receiver = c.Receiver,
                    Model = c.Model,
                    SNumber = c.SNumber,
                    QNumber = c.QNumber,
                    PublicView = c.PublicView
                })
                .ToList();

            return View(cardsl);

        }

        public IActionResult BlankCards()
        {
            var cards = this.data.Cards
                .ToList();

            var cardsl = cards
                .Select(c => new CardAllViewModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    Destination = c.Destination
                })
                .ToList();

            return View(cardsl);

        }

        public IActionResult AllPublicQuotes()
        {
            var quotes = this.data.Quotes.ToList();

            var quotesl = quotes
                .Select(c => new QuoteAllViewModel
                {
                    Id = c.Id,
                    AuthorName = c.AuthorName,
                    Description = c.Description
                })
                .ToList();

            return View(quotesl);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdminQuotes()
        {

            var quotesl = this.data.Quotes
                .Select(c => new QuoteAllViewModel
                {
                    Id = c.Id,
                    AuthorName = c.AuthorName,
                    Description = c.Description
                })
                .ToList();

            return View(quotesl);

        }

        public IActionResult AllPublicStickers()
        {

            var stickersl = this.data.Stickers
                .Select(c => new StickerAllViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl
                })
                .ToList();

            return View(stickersl);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdminStickers()
        {

            var stickersl = this.data.Stickers
                .Select(c => new StickerAllViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                    SNumber = c.SNumber
                })
                .ToList();

            return View(stickersl);

        }

        public IActionResult AllPublicAuthors()
        {
            var authors = this.data.Authors
                .ToList();

            var authorsl = authors
                .Select(c => new AuthorAllViewModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    ImageUrl = c.ImageUrl 
                })
                .ToList();

            return View(authorsl);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdminAuthors()
        {
            var authors = this.data.Authors
                .ToList();

            var authorsl = authors
                .Select(c => new AuthorAllAdminViewModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    ImageUrl = c.ImageUrl.ToString()
                })
                .ToList();

            return View(authorsl);

        }

        public IActionResult AllPublicArtists()
        {
            var artists = this.data.Artists
                .ToList();

            var artistsl = artists
                .Select(a => new ArtistAllViewModel
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    ImageUrl = a.ImageUrl
                })
                .ToList();

            return View(artistsl);

        }
        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdminArtists()
        {
            var artists = this.data.Artists
                .ToList();

            var artistsl = artists
                .Select(a => new ArtistAllViewModel
                {
                    FullName = a.FullName,
                    ImageUrl = a.ImageUrl.ToString(),
                    SImageUrl = a.SImageUrl.ToString()
                })
                .ToList();

            return View(artistsl);

        }
    }
}
