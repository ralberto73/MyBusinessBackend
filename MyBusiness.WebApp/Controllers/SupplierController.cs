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
                    _data_repository.Suppliers.Update(supplier, "usert update");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        #region APIs

        [HttpGet]
            public IActionResult GetAll()
            {
                return Json(new { data = _data_repository.Suppliers.GetAll() });
            }

        /// <summary>
        ///   Deletes a Supplier
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int rows_deleted = _data_repository.Suppliers.Delete(id); // <--
            if (rows_deleted == 0)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            return Json(new { success = "true", message = "Delete successfully." });
        }

        #endregion
    }
}
