﻿using Quinterest2.Models;
using Quinterest2.Services;
using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            return View(_service.List());
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
                _service.Create(board);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var original = _service.Find(id.Value);
            return View(original);
        }

        // POST: Boards/Edit/5
        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(board);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var original = _service.Find(id.Value);
            return View(original);
        }

        // POST: Boards/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
