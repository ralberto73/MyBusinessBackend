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

        //  Update and Insert  Action 
        //  if id is null => Insert 
        //        else    => Insert
        public IActionResult Upsert(int? id)
        {
            Insurance insurance = new Insurance();
            if (id == null)
            {
                return View(insurance);
            }
            insurance = _data_repository.Insurances.GetById(id.GetValueOrDefault());
            if (insurance == null)
            {
                return NotFound();
            }
            return View(insurance);
        }

        //  Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                if (insurance.InsuranceId == 0)
                {
                    // _unitOfWork.Category.Add(category);
                    _data_repository.Insurances.AddNew(insurance, "insert user");
                }
                else
                {
                    //  _unitOfWork.Category.Update(category);
                    _data_repository.Insurances.Update(insurance, "user update");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(insurance);
        }


        // POST: InsuranceController/Delete/5
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _data_repository.Insurances.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int rows_deleted = _data_repository.Insurances.Delete(id);
            if (rows_deleted == 0)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            return Json(new { success = "true", message = "Delete successfully." });
        }


        #endregion
    }
}
