using Quinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Quinterest.Views.Boards;

namespace Quinterest.Controllers
{
    public class BoardsController : Controller
    {
        private DataContext _db = new DataContext();
        // GET: Boards
        public ActionResult Index()
        {
            var boards = from b in _db.Boards.Include(b => b.Category) select b;
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
            var vm = new CreateVM
            {
                Categories = new SelectList(_db.Categories.ToList(), "Id", "Name")

            };

            return View(vm);
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
            var vm = new EditVM
            {
                Board = _db.Boards.Find(id),
                Categories = new SelectList(_db.Categories.ToList(), "Id", "Name")

            };
         
            return View(vm);
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
                original.CategoryId = board.CategoryId;
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
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            var original = _db.Boards.Find(id);
            _db.Boards.Remove(original);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
