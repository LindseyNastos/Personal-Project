using Quinterest2.Models;
using Quinterest2.Services;
using Quinterest2.Views.Pins;
using System;
using Microsoft.AspNet.Identity;
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


        // GET: Pins
        public ActionResult Index()
        {
            return View(_service.List());
        }


        // GET: Pins/Details/5
        public ActionResult Details(int id)
        {

            var user = this.User.Identity.GetUserId();
            var vm = new DetailsVM
            {
                Pins = _service.Find(id),
                Boards = new SelectList(_service.BoardList(user), "Id", "BoardName"),
            };

            return View(vm);
        }

        // POST: Pins/Details
        [HttpPost]
        public ActionResult Details(Pin pin, ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                
                var board = pin.Board;
                _service.PinIt(pin, user, board);
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: Pins/Create
        public ActionResult Create()
        {
            var user = this.User.Identity.GetUserId();
            var vm = new CreateVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name"),
                Boards = new SelectList(_service.BoardList(user), "Id", "BoardName")
            };
            return View(vm);
        }

         //POST: Pins/Create
        [HttpPost]
        public ActionResult Create(Pin pin)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                pin.UserId = userId;
                _service.Create(pin, userId);
                var id = pin.BoardId;
                return RedirectToAction("Index", "Boards", new { id });
            }
            return View();
        }

         //GET: Pins/Edit/5
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
                return RedirectToAction("Details", new { id = pin.Id });
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
            var original = _service.FindBoard(id.Value);
            return View(original);
        }

        // POST: Pins/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            
            var board = _service.Find(id).BoardId;
            _service.Delete(id);
            return RedirectToAction("Index", "Boards", new { id = board });
        }
    }
}
