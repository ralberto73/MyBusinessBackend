using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.WebApp.Controllers
{
    public class ServiceOrdersController : Controller
    {
        private IDataRepository _data_repository;
        public ServiceOrdersController(IDataRepository data_repository)
        {
            _data_repository = data_repository;
        }

        // GET: ServiceOrdersController
        public ActionResult Index()
        {
            return View(_data_repository.ServiceOrders.GetAll());
        }

        // GET: ServiceOrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceOrdersController/Create
        public ActionResult Create()
        {
            fill_Data(ViewData);
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind ("Contact,Email,PhoneNumber,AddressLine1,AddressLine2,City,State,ZipCode,BrandId,Model,SubModel,Year,ProductId,PaymentMethod,InsuranceId,SupplierId,BillableAmount,LaborAmount,PartCost")] ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                // int i = _data_repository.Se.AddNew(serviceOrder);
                // await _context.SaveChangesAsync();
                serviceOrder.CreatedBy = "kundo";
                serviceOrder.UpdatedBy = "kundo";
                _data_repository.ServiceOrders.AddNew(serviceOrder);
                return RedirectToAction(nameof(Index));
            }
            return View(serviceOrder);
        }

        // GET: ServiceOrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceOrdersController/Edit/5
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

        // GET: ServiceOrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceOrdersController/Delete/5
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

        private void fill_Data(ViewDataDictionary viewData)
        {
            ViewData["BrandList"] = _data_repository
                                       .Brand
                                       .GetAll()
                                       .Select(b => new SelectListItem
                                       {
                                           Value = b.BrandId.ToString(),
                                           Text = b.BrandName
                                       }).ToList();

            ViewData["InsuranceList"] = _data_repository
                           .Insurances
                           .GetAll()
                           .Select(i => new SelectListItem
                           {
                               Value = i.InsuranceId.ToString(),
                               Text = i.InsuranceName
                           }).ToList();
            ViewData["ProductList"] = _data_repository
                                      .Products
                                      .GetAll()
                                      .Select(p => new SelectListItem
                                      {
                                          Value = p.ProductId.ToString(),
                                          Text = p.ProductName
                                      }).ToList();
            ViewData["SupplierList"] = _data_repository
                           .Suppliers
                           .GetAll()
                           .Select(s => new SelectListItem
                           {
                               Value = s.SupplierId.ToString(),
                               Text = s.SupplierName
                           }).ToList();
            ViewData["PaymentMethodList"] = new List<SelectListItem>() {
                                                new SelectListItem { Value="-" ,Text = "Select Payment Method" },
                                                new SelectListItem { Value="P" ,Text = "Personal Payment" },
                                                new SelectListItem { Value="I" ,Text = "Insurance" }
                                            };
           ViewData["YearList"] = Enumerable.Range(DateTime.Now.Year - 30, 33)
                                  .Reverse<int>()
                                  .Select ( i => new SelectListItem
                                  {
                                      Value = i.ToString(),
                                      Text = i.ToString()
                                  }).ToList();

        }
    }
}
