using DigitalCardsAppll.Data;
using DigitalCardsAppll.Models.Cards;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DigitalCardsAppll.Controllers
{
    public class CardsController : Controller
    {

        private readonly DigitalCardsDbContext data;

        public CardsController(DigitalCardsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(CardAddViewModel card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }
    

            var cardd = new Card
            {
                Title = card.Title,
                Destination = card.Destination,
                ImageUrl = card.ImageUrl,
                Receiver = card.Receiver,
                Model = card.Model,
                SNumber = card.SNumber,
                QNumber = card.QNumber,
                PublicView = card.PublicView
            };
           
            this.data.Cards.Add(cardd);
            this.data.SaveChanges();       

            return RedirectToAction("All", "Cards");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AddBlank(CardAddAdminViewModel card)
        {
            if (!ModelState.IsValid)
            {
                return View(card);
            }

            var cardr = new Card
            {
                ImageUrl = card.ImageUrl,
                Destination = card.Destination
            };

            this.data.Cards.Add(cardr);
            this.data.SaveChanges();

            return RedirectToAction("BlankCards", "Collection");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AllBlank(CardAllAdminViewModel card)
        {

            var cardsl = this.data.Cards
               .OrderByDescending(x => x.Id)
               .Select(c => new CardAllAdminViewModel
               {
                   Id = c.Id,
                   ImageUrl = c.ImageUrl,
                   Destination = c.Destination
               })
               .ToList();

            return View(cardsl);
        }

        public IActionResult All()
        {
            var cards = this.data.Cards
                .Where(c => c.PublicView == true).ToList();

            var cardsl = cards
                .OrderByDescending(x => x.Id)
                .Select(c => new CardAllViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                    Destination = c.Destination
                })
                .ToList();

            return View(cardsl);

        }

        public IActionResult Details(int cardId)
        {

            var card = this.data.Cards.Where(c => c.Id == cardId)
                .Select(c => new CardDetailsViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                    Destination = c.Destination,
                    SNumber = c.SNumber,
                    QNumber = c.QNumber
                })
                .FirstOrDefault();

            return View(card);

        }

        public IActionResult Delete(int cardId)
        {
            var card = this.data.Cards.Where(x => x.Id == cardId).First();

            if (card == null)
            {
                return BadRequest();
            }

            this.data.Cards.Remove(card);
            this.data.SaveChanges();

            return RedirectToAction("All", "Cards");
        }

        [HttpPost]
        public IActionResult EditPublicView(int cardId)
        {
            var card = this.data.Cards.Where(x => x.Id == cardId).FirstOrDefault();

            if (card == null)
            {
                return BadRequest();
            }

            if (card.PublicView)
            {
                card.PublicView = false;
            }

            card.PublicView = true;

            this.data.SaveChanges();

            return RedirectToAction("All", "Cards");
        }

        public IActionResult Edit(int cardId, CardEditViewModel card)
        {
            var cardm = this.data.Cards.Where(x => x.Id == cardId).FirstOrDefault();

            if (card == null)
            {
                return BadRequest();
            }

            cardm.Title = card.Title;
            cardm.Model = card.Model;
            cardm.Receiver = card.Receiver;
            cardm.SNumber = card.SNumber;
            cardm.QNumber = card.QNumber;
            cardm.PublicView = card.PublicView;

            this.data.SaveChanges();

            return RedirectToAction("All", "Cards");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult EditTitleAdmin(int cardId, CardEditViewModel card)
        {
            var cardm = this.data.Cards.Where(x => x.Id == cardId).FirstOrDefault();

            if (card == null)
            {
                return BadRequest();
            }

            cardm.Title = card.Title;

            this.data.SaveChanges();

            return RedirectToAction("All", "Cards");
        }



    }
}
