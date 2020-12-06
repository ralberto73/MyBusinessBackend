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
        public IActionResult Index()
        {
            var a = _data_repository.ServiceOrdersStatus.GetAll().ToList();
            return View(a);
        }
    }
}
