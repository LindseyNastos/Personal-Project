using Quinterest2.Models;
using Quinterest2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace Quinterest2.Controllers
{
    public class CommentsController : Controller
    {

        private ICommentServices _service;

        public CommentsController(ICommentServices service)
        {

            _service = service;
        }




        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(Comment comment, int id)
        {
            
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                _service.Create(comment, id, userId);
                return RedirectToAction("Details", "Pins", new { id = id });
            }
            return View();
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comments/Edit/5
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

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comments/Delete/5
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
