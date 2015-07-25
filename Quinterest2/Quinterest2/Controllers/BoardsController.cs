using Quinterest2.Models;
using Quinterest2.Services;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest2.Controllers
{
    public class BoardsController : Controller
    {
        private IBoardServices _service;

        public BoardsController(IBoardServices service)
        {
            _service = service;
        }

        // GET: Boards
        public ActionResult Index(int id)
        {
            return View(_service.Find(id));
        }

        // GET: Boards/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.Find(id));
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boards/Create
        [HttpPost]
        public ActionResult Create(Board board)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                board.UserId = userId;
                _service.Create(board, userId);
                return RedirectToAction("ApplicationUserView", "ApplicationUsers");
            }
            return View();
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _service.Find(id);
            return View(model);
        }

        // POST: Boards/Edit/5
        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(board);
                return RedirectToAction("Index", new { id = board.Id });
            }
            return View();
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int id)
        {
            var original = _service.Find(id);
            return View(original);
        }

        // POST: Boards/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            var userId = User.Identity.GetUserId();
            _service.Delete(id, userId);
            return RedirectToAction("ApplicationUserView", "ApplicationUsers");
        }
    }
}
