using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
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
            return View(  _data_repository.ServiceOrdersStatus
                                          .GetAll()
                                          .ToList() );
        }
    #region APIs

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _data_repository.ServiceOrdersStatus.GetAll() });
        }
    #endregion
    }

}
