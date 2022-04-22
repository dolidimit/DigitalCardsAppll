using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Stickers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class StickersController : Controller
    {

        private readonly DigitalCardsDbContext data;

        public StickersController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(StickerAddViewModel sticker)
        {
            if (!ModelState.IsValid)
            {
                return View(sticker);
            }

            var stickerr = new Sticker
            {
                Title = sticker.Title,
                ImageUrl = sticker.ImageUrl,
                Topic = sticker.Topic,
                ArtistName = sticker.ArtistName,
                Size = sticker.Size,
                SNumber = sticker.SNumber
            };

            this.data.Stickers.Add(stickerr);
            this.data.SaveChanges();

            return RedirectToAction("All", "Stickers");
        }

        public IActionResult All()
        {

            var stickersl = this.data.Stickers
                .OrderByDescending(x => x.Id)
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

        public IActionResult Details(int stickerid)
        {
            if (stickerid == 0)
            {
                return BadRequest();
            }

            var stickerd = this.data.Stickers
                .Where(x => x.Id == stickerid)
                .Select(c => new StickerDetailsViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                    SNumber = c.SNumber
                })
                .First();

            return View(stickerd);

        }

        public IActionResult Delete(string stickerid)
        {

            var sticker = this.data.Stickers.Find(stickerid);

            if (sticker == null)
            {
                return BadRequest();
            }

            this.data.Stickers.Remove(sticker);
            this.data.SaveChanges();

            return View(sticker);

        }

        public IActionResult Edit(string stickerid, StickerEditViewModel sticker)
        {
            var stickeri = this.data.Stickers.Find(stickerid);

            stickeri.Title = sticker.Title;
            stickeri.ArtistName = sticker.ArtistName;
            stickeri.Topic = sticker.Topic;
            stickeri.Size = sticker.Size;
            stickeri.SNumber = sticker.SNumber;

            this.data.SaveChanges();

            return View(sticker);

        }

    }
}
