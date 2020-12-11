using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class ServiceOrderStatusController : Controller
    {
        private IDataRepository _data_repository;
        public ServiceOrderStatusController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }

        /// <summary>
        ///   List of posibles Services Order Status 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_data_repository.ServiceOrdersStatus
                                          .GetAll()
                                          .ToList());
        }

        //  Update and Insert  Action 
        //  if id is null => Insert 
        //        else    => Insert
        public IActionResult Upsert(int? id)
        {
            ServiceOrderStatus service_satatus = new ServiceOrderStatus ();
            if (id == null)
            {
                return View(service_satatus);
            }
            service_satatus = _data_repository.ServiceOrdersStatus.GetById(id.GetValueOrDefault());
            if (service_satatus == null)
            {
                return NotFound();
            }
            return View(service_satatus);
        }

        //  Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ServiceOrderStatus service_order_status)
        {
            if (ModelState.IsValid)
            {
                    if (service_order_status.Color == null)
                        service_order_status.Color = "white";
                    if (service_order_status.IconPicture == null)
                        service_order_status.IconPicture = string.Empty;                
                if (service_order_status.ServiceOrderStatusId == 0)
                {

                    _data_repository.ServiceOrdersStatus.AddNew(service_order_status, "insert user");
                }
                else
                {
                    //  _unitOfWork.Category.Update(category);
                    _data_repository.ServiceOrdersStatus.Update(service_order_status, "user update");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(service_order_status);
        }


        #region APIs

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _data_repository.ServiceOrdersStatus.GetAll() });
        }

        /// <summary>
        ///   Deletes a Product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int rows_deleted = _data_repository.ServiceOrdersStatus.Delete(id); // <--
            if (rows_deleted == 0)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            return Json(new { success = "true", message = "Delete successfully." });
        }
        #endregion
    }

}
