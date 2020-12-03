using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class UserManagerController : Controller
    {
        // private UserManager<>
        private readonly UserManager<IdentityUser> _userManager;
        public UserManagerController(UserManager<IdentityUser> userManager )
        {
            _userManager = userManager;
            var a = _userManager.Users;
        }

        // GET: UserManagerController
        public ActionResult Index( )
        {
            return View();
        }

        // GET: UserManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
