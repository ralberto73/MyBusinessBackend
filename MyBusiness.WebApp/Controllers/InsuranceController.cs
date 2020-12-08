using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class InsuranceController : Controller
    {

        private IDataRepository _data_repository;
        public InsuranceController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }
        // GET: InsuranceController
        public ActionResult Index()
        {
            return View(_data_repository.Insurances.GetAll());
        }

        // GET: InsuranceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsuranceName")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                int i = _data_repository.Insurances.AddNew(insurance, "raul");
                // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurance);
        }

        // GET: InsuranceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceController/Edit/5
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

        // GET: InsuranceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceController/Delete/5
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

        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _data_repository.Insurances.GetAll() });
        }



        #endregion
    }
}
