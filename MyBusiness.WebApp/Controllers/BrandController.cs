﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class BrandController : Controller
    {
        private IDataRepository _data_repository;
        public BrandController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }
        
        // GET: BrandController
        public ActionResult Index()
        {
            return View( _data_repository.Brand.GetAll());
        }

        // GET: BrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandName")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                int i = _data_repository.Brand.AddNew(brand, "raul");
                // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: BrandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrandController/Edit/5
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

        //// GET: BrandController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: BrandController/Delete/5
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
            return Json(new { data = _data_repository.Brand.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            /*
             * var  
             
             */
            
            
            return Json(new { success="true" , message="Delete successfully." });
        }

        #endregion
    }
}
