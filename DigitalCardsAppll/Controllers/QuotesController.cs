using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Quotes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class QuotesController : Controller
    {
        private readonly DigitalCardsDbContext data;

        public QuotesController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(QuoteAddViewModel quote)
        {
            if (!ModelState.IsValid)
            {
                return View(quote);
            }

            var quoten = new Quote
            {
                AuthorName = quote.AuthorName,
                Year = quote.Year,
                Genre = quote.Genre,
                Description = quote.Description,
                QNumber = quote.QNumber
            };

            this.data.Quotes.Add(quoten);
            this.data.SaveChanges();

            return RedirectToAction("All", "Quotes");
        }

        public IActionResult All()
        {

            var quotesl = this.data.Quotes
                .OrderByDescending(x => x.Id)
                .Select(c => new QuoteAllViewModel
                {
                    Id = c.Id,
                    AuthorName = c.AuthorName,
                    Description = c.Description
                })
                .ToList();

            return View(quotesl);

        }

        public IActionResult Details(int quoteid)
        {
            var cards = this.data.Quotes.ToList();

            var card = cards.Where
                (c => c.Id == quoteid)
                .Select(c => new QuoteDetailsViewModel
                {
                    Id = c.Id,
                    Genre = c.Genre,
                    QNumber = c.QNumber
                })
                .FirstOrDefault();

            return View(card);

        }

        public IActionResult Delete(string quoteid)
        {
            var quote = this.data.Quotes.Find(quoteid);

            if (quote == null)
            {
                return BadRequest();
            }

            this.data.Quotes.Remove(quote);
            this.data.SaveChanges();

            return RedirectToAction("All", "Quotes");

        }

        public IActionResult Edit(string quoteid, QuoteEditViewModel quotem)
        {
            var quote = this.data.Quotes.Find(quoteid);

            if (quote == null)
            {
                return BadRequest();
            }

            quote.AuthorName = quotem.AuthorName;
            quote.Description = quotem.Description;
            quote.Genre = quotem.Genre;
            quote.QNumber = quotem.QNumber;

            this.data.SaveChanges();

            return View(quotem);

        }

    }
}
