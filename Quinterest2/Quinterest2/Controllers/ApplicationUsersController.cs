using Quinterest2.Models;
using Quinterest2.Services;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quinterest2.Views.ApplicationUsers;

namespace Quinterest2.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private IApplicationUserServices _service;

        public ApplicationUsersController(IApplicationUserServices service)
        {
            _service = service;
        }
        
        //GET: User
        public ActionResult ApplicationUserView()
        {
            var user = _service.Find(this.User.Identity.GetUserId());
            user.NumBoards = _service.QNumBoards(user.Id);
            user.NumPins = _service.QNumPins(user.Id);

            return View(user);
        }

        //GET: Users/Edit/5
        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            var model = _service.Find(userId);
            return View(model);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(user);
                return RedirectToAction("ApplicationUserView");
            }
            return View();
        }

        public ActionResult AdminView()
        {
            var vm = new AdminViewVM
            {
                Flags = _service.FlagList()
            };
            return View(vm);
        }
    }
}
