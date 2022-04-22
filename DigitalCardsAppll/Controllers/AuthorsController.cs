using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Author;
using DigitalCardsAppll.Models.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly DigitalCardsDbContext data;

        public AuthorsController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AuthorAddViewModel author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            var authorr = new Author
            {
                FullName = author.FullName,
                ImageUrl = author.ImageUrl,
                PQuote = author.PQuote
            };

            this.data.Authors.Add(authorr);
            this.data.SaveChanges();

            return RedirectToAction("All", "Authors");
        }




        public IActionResult All()
        {
            var authors = this.data.Authors
                .ToList();

            var authorsl = authors
                .OrderByDescending(x => x.Id)
                .Select(c => new AuthorAllViewModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    ImageUrl = c.ImageUrl,
                    PQuote = c.PQuote
                })
                .ToList();

            return View(authorsl);

        }

        public IActionResult Delete(int authorid)
        {
            var authors = this.data.Authors
                .ToList();

            var author = authors.Where(x => x.Id == authorid).FirstOrDefault();

            authors.Remove(author);
            this.data.SaveChanges();

            return RedirectToAction("All", "Authors");

        }
        public IActionResult Edit(int authorid, AuthorEditViewModel auth)
        {
            var authors = this.data.Authors
                .ToList();

            var author = authors
                .Where(x => x.Id == authorid).FirstOrDefault();

            author.FullName = auth.FullName;
            author.ImageUrl = auth.ImageUrl;
            author.PQuote = auth.PQuote;

            this.data.SaveChanges();

            return View(author);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdmin()
        {
            var authors = this.data.Authors
                .ToList();

            var authorsl = authors
                .OrderByDescending(x => x.Id)
                .Select(c => new AuthorAllAdminViewModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    ImageUrl = c.ImageUrl.ToString(),
                    PQuote = c.PQuote
                })
                .ToList();

            return View(authorsl);

        }
    }
}
