﻿using Quinterest2.Models;
using Quinterest2.Services;
using Quinterest2.Views.Pins;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quinterest2.Views.Shared;
using Quinterest2.PermissionsHelper;

namespace Quinterest2.Controllers
{
    public class PinsController : Controller
    {
        private IPinServices _service;

        public PinsController(IPinServices service)
        {
            _service = service;
        }

        public ActionResult Search(string everything, int pageIndex = 0)
        {
            var userId = this.User.Identity.GetUserId();
            return View(_service.SearchResults(userId, everything, pageIndex));
        }

        [ChildActionOnly]
        public ActionResult CategorySearch()
        {
            var vm = new CategoryPartialVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name")
            };

            return PartialView("_CategoryListPartial", vm);
        }

        [HttpPost]
        public ActionResult CategorySearchResults(CategoryPartialVM vm, int pageIndex = 0)
        {
            var userId = this.User.Identity.GetUserId();
            return View(_service.CategoryPages(userId, pageIndex, vm.Pin.CategoryId));
        }

        // GET: Pins
        public ActionResult Index(int pageIndex = 0)
        {
            var userId = this.User.Identity.GetUserId();
            return View(_service.Pages(userId, pageIndex));
        }

        // GET: Pins/Details/5
        public ActionResult Details(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (userId == null) {
                return RedirectToAction("Register", "Account");
            }

            else {
                var pinUserId = _service.FindPinUserId(id);

                var vm = new DetailsVM
                {
                    PinnerDisplayName = _service.FindUserName(pinUserId),
                    Pin = _service.Find(id),
                    CurrentUser = _service.FindUser(userId),
                    Comments = _service.CommentList(id),
                    RelatedPins = _service.GetRelatedPins(id)
                };
                return View(vm);
            }
        }

        // Get: Pins/PinItView
        public ActionResult PinItView(int id)
        {
            var user = this.User.Identity.GetUserId();
            var vm = new PinItViewVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name"),
                Boards = new SelectList(_service.BoardList(user), "Id", "BoardName"),
                Pin = _service.Find(id)
            };
            return View(vm);
        }

        // POST: Pins/PinItView
        [HttpPost]
        public ActionResult PinItView(Pin pin)
        {
            var userId = this.User.Identity.GetUserId();
            var boardId = pin.BoardId;
            _service.PinIt(pin, userId, boardId);
            return RedirectToAction("Details", new { id = pin.Id });
        }

        // GET: Pins/Create
        [Authorize]
        public ActionResult Create()
        {
            var userId = this.User.Identity.GetUserId();
            var vm = new CreateVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name"),
                Boards = new SelectList(_service.BoardList(userId), "Id", "BoardName")
            };

            var user = _service.FindUser(userId);
            if (user.NumBoards == 0)
            { 
                return RedirectToAction("Create", "Boards");
            }
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
                pin.IsActive = true;
                _service.Create(pin, userId);
                var boardId = pin.BoardId;
                return RedirectToAction("Index", "Boards", new { id = boardId });
            }
            return View();
        }

         //GET: Pins/Edit/5
        public ActionResult Edit(int id)
        {
            var user = this.User.Identity.GetUserId();
            var vm = new EditVM
            {
                Categories = new SelectList(_service.CategoryList(), "Id", "Name"),
                Pin = _service.Find(id),
                Boards = new SelectList(_service.BoardList(user), "Id", "BoardName")
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
        public ActionResult Delete(int id)
        {
            var original = _service.Find(id);
            return View(original);
        }

        // POST: Pins/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            var boardId = _service.Find(id).BoardId;
            var userId = this.User.Identity.GetUserId();
            _service.Delete(id);
            if (ClaimsHelper.UserIsAdmin())
            {
                return RedirectToAction("AdminView", "ApplicationUsers");
            }
            else
            {
                return RedirectToAction("Index", "Boards", new { id = boardId });
            }
        }

        // Post: Pins/AddFlag/5
        [HttpPost]
        public ActionResult AddFlag(int id)
        {
            var userId = this.User.Identity.GetUserId();
            _service.FlagThis(id, userId);
            return new EmptyResult();
        }

        public ActionResult NotificationList()
        {
            var userId = this.User.Identity.GetUserId();
            var notes = _service.GetNotifications(userId);
            return View(notes);
        }
    }
}
