﻿using Quinterest2.Models;
using Quinterest2.Services;
using Quinterest2.Views.Pins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest2.Controllers
{
    public class PinsController : Controller
    {
        private IPinServices _service;

        public PinsController(IPinServices service)
        {
            _service = service;
        }

        //GET: Pins/PinIt
        public ActionResult PinIt(int id)
        {
            return View();
        }

        //POST: Pins/PinIt
        [HttpPost]
        public ActionResult PinIt(int id, Pin pin)
        {
            _service.PinToBoard(id, pin);
            return RedirectToAction("Index");
        }


        //Joshua's:
        //var whatever = User.Identity.GetUserId(something in here)


        // GET: Pins
        public ActionResult Index()
        {
            return View(_service.List());
        }

        // GET: Pins/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.Find(id));
        }

        // GET: Pins/Create
        public ActionResult Create()
        {
            var vm = new CreateVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name")
            };
            return View(vm);
        }

        // POST: Pins/Create
        [HttpPost]
        public ActionResult Create(Pin pin)
        {
            if (ModelState.IsValid)
            {
                _service.Create(pin);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Pins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var vm = new EditVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name"),
                Pin = _service.Find(id.Value)
            };

            return View(vm);
        }

        // POST: Pins/Edit/5
        [HttpPost]
        public ActionResult Edit(Pin pin)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(pin);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Pins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var original = _service.Find(id.Value);
            return View(original);
        }

        // POST: Pins/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
