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
    }
}
