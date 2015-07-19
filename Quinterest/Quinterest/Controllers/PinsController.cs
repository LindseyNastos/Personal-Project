using Quinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Quinterest.Views.Pins;


namespace Quinterest.Controllers
{
    public class PinsController : Controller
    {
        private DataContext _db = new DataContext();

        // GET: Pins
        public ActionResult Index()
        {
            var pins = from p in _db.Pins.Include(p => p.PinCategory) select p;
            return View(pins.ToList());
        }

        // GET: Pins/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pins/Create
        public ActionResult Create()
        {
            var vm = new CreateVM
            {
                PinCategories = new SelectList(_db.PinCategories.ToList(), "Id", "Name")

            };

            return View(vm);
        }

        // POST: Pins/Create
        [HttpPost]
        public ActionResult Create(Pin pin)
        {
            if (ModelState.IsValid)
            {
                _db.Pins.Add(pin);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Pins/Edit/5
        public ActionResult Edit(int id)
        { 
            var vm = new EditVM
            {
                Pin = _db.Pins.Find(id),
                PinCategories = new SelectList(_db.PinCategories.ToList(), "Id", "Name")

            };

            return View(vm);
        }

        // POST: Pins/Edit/5
        [HttpPost]
        public ActionResult Edit(Pin pin)
        {
            if (ModelState.IsValid)
            {
                var original = _db.Pins.Find(pin.Id);
                original.Title = pin.Title;
                original.ImageUrl = pin.ImageUrl;
                original.Website = pin.Website;
                original.PinCategoryId = pin.PinCategoryId;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        // GET: Pins/Delete/5
        public ActionResult Delete(int id)
        {
            var pin = _db.Pins.Find(id);
            return View(pin);
        }

        // POST: Pins/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            var original = _db.Pins.Find(id);
            _db.Pins.Remove(original);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
