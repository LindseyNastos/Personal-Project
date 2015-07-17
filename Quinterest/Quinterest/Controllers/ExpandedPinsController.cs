using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Controllers
{
    public class ExpandedPinsController : Controller
    {
        // GET: ExpandedPins
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExpandedPins/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpandedPins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpandedPins/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpandedPins/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpandedPins/Edit/5
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

        // GET: ExpandedPins/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpandedPins/Delete/5
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
