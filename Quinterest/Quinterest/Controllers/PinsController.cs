using Quinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Controllers
{
    public class PinsController : Controller
    {
        // GET: Pins
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pins/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pins/Create
        [HttpPost]
        public ActionResult Create(Pin pin)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
                return View();
        }

        // GET: Pins/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pins/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pins/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pins/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
