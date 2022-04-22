using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Artists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class ArtistsController : Controller
    {

        private readonly DigitalCardsDbContext data;

        public ArtistsController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(ArtistAddViewModel artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }

            var artist2 = new Artist
            {
                FullName = artist.FullName,
                ImageUrl = artist.ImageUrl,
                SImageUrl = artist.SImageUrl
            };

            this.data.Artists.Add(artist2);
            this.data.SaveChanges();

            return RedirectToAction("All", "Artists");
        }

        public IActionResult All()
        {
            var artists = this.data.Artists
                .ToList();

            var artistsl = artists
                .OrderByDescending(x => x.Id)
                .Select(a => new ArtistAllViewModel
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    ImageUrl = a.ImageUrl
                })
                .ToList();

            return View(artistsl);

        }

        public IActionResult Delete(int artistid)
        {
            var artists = this.data.Artists
                .ToList();

            var artist = artists.Where(x => x.Id == artistid).FirstOrDefault();

            artists.Remove(artist);
            this.data.SaveChanges();

            return RedirectToAction("All", "Artists");

        }
        public IActionResult Edit(int artistid,ArtistEditViewModel artist)
        {
            var artists = this.data.Artists
                .ToList();

            var artistsl = artists
                .Where(x => x.Id == artistid).FirstOrDefault();

            artistsl.FullName = artist.FullName;
            artistsl.ImageUrl = artist.ImageUrl;
            artistsl.SImageUrl = artist.SImageUrl;

            return View(artistsl);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllAdmin()
        {
            var artists = this.data.Artists
                .ToList();

            var count = this.data.Artists.Count();

            var artistsl = artists
                .OrderByDescending(x => x.Id)
                .Select(a => new ArtistAllAdminViewModel
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    ImageUrl = a.ImageUrl.ToString(),
                    SImageUrl = a.SImageUrl.ToString()
                })
                .ToList();

            return View(artistsl);

        }

    }
}
