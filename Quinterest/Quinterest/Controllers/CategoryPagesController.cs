using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Controllers
{
    public class CategoryPagesController : Controller
    {
        // GET: CategoryPages
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryPages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryPages/Create
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

        // GET: CategoryPages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryPages/Edit/5
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

        // GET: CategoryPages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryPages/Delete/5
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
