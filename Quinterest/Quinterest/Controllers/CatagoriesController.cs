using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Controllers
{
    public class CatagoriesController : Controller
    {
        // GET: Catagories
        public ActionResult Index()
        {
            return View();
        }

        // GET: Catagories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Catagories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catagories/Create
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

        // GET: Catagories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catagories/Edit/5
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

        // GET: Catagories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catagories/Delete/5
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
