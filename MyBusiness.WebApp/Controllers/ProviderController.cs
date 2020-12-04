using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class ProviderController : Controller
    {

        private IDataRepository _data_repository;
        public ProviderController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
