using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBusiness.DataAccess;
using MyBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBusiness.Apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        IDataRepository _data_repository;
        public SuppliersController(IDataRepository dataRepository)
        {
            _data_repository = dataRepository;
        }

        // GET: SuppliersController
        [HttpGet]
        public IEnumerable<Supplier> GetAll()
        {
            return _data_repository.Suppliers.GetAll();
           // return new List<Supplier>();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            return _data_repository.Suppliers.GetById(id);
        }

         [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] Supplier new_supplier)
        {
            var r = _data_repository.Suppliers.AddNew(new_supplier, "kundo");
            return Ok(r);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] Supplier current_supplier)
        {
            var r = _data_repository.Suppliers.Update(current_supplier, "kundo");
            return Ok();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int  id)
        {
            var r = _data_repository.Suppliers.Delete(id);
            return Ok(r);
        }


    }    
   
}
