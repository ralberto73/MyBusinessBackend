using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class ServiceOrdersController : Controller
    {
        // GET: ServiceOrdersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServiceOrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceOrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceOrdersController/Create
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

        // GET: ServiceOrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceOrdersController/Edit/5
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

        // GET: ServiceOrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceOrdersController/Delete/5
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
