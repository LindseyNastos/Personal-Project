using Quinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Controllers
{
    public class BoardsController : Controller
    {
        private BoardsDB _db = new BoardsDB();
        // GET: Boards
        public ActionResult Index()
        {
            var boards = from b in _db.Boards select b;
            return View(boards.ToList());
        }

        // GET: Boards/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                _db.Boards.Add(board);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int id)
        {
            var board = _db.Boards.Find(id);
            return View(board);
        }

        // POST: Boards/Edit/5
        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                var original = _db.Boards.Find(board.Id);
                original.BoardName = board.BoardName;
                original.Description = board.Description;
                original.Secret = board.Secret;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int id)
        {
            var board = _db.Boards.Find(id);
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var original = _db.Boards.Find(id);
            _db.Boards.Remove(original);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
