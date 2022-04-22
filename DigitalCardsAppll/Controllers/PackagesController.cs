using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Packages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class PackagesController : Controller

    {
        private readonly DigitalCardsDbContext data;

        public PackagesController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(PackageAddViewModel package)
        {
            if (!ModelState.IsValid)
            {
                return View(package);
            }

            var packagen = new Package
            {
                Name = package.Name,
                Cards = new List<Card>()
            };

            this.data.Packages.Add(packagen);
            this.data.SaveChanges();

            return RedirectToAction("All", "Packages");
        }

        public IActionResult Details(int packageId)//YourPackage button
        {

            var package = this.data.Packages.Where(p => p.Id == packageId).FirstOrDefault();

            var pack = package.Cards
                .Select(c => new PackageAllViewModel
                {
                    Id = c.Id
                })
                .ToList();

            return View(pack);

        }

        public IActionResult AddCard(int packageId, int cardid)
        {

            var package = this.data.Packages.Where(p => p.Id == packageId).FirstOrDefault();
            var card = this.data.Cards.Where(p => p.Id == cardid).FirstOrDefault();

            package.Cards.Add(card);

            return RedirectToAction("All", "Packages");

        }
    }
}
