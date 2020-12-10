using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class SupplierController : Controller
    {
        private IDataRepository _data_repository;
        public SupplierController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }
        public IActionResult Index()
        {
            return View(_data_repository.Suppliers.GetAll());
        }

        //  Update and Insert  Action 
        //  if id is null => Insert 
        //        else    => Insert
        public IActionResult Upsert(int? id)
        {
           Supplier supplier = new Supplier();
            if (id == null)
            {
                return View(supplier);
            }
            supplier = _data_repository.Suppliers.GetById(id.GetValueOrDefault());
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        //  Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.SupplierId == 0)
                {
                    // _unitOfWork.Category.Add(category);
                    _data_repository.Suppliers.AddNew(supplier, "insert user");
                }
                else
                {
                    //  _unitOfWork.Category.Update(category);
                    _data_repository.Suppliers.Update(supplier, "user update");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
        /*
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierName")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                int i = _data_repository.Suppliers.AddNew(supplier, "raul");
                // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
        */
        #region APIs

        [HttpGet]
            public IActionResult GetAll()
            {
                return Json(new { data = _data_repository.Suppliers.GetAll() });
            }



        #endregion
    }
}
