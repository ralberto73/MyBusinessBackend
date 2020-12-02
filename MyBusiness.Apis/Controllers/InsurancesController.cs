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
    public class InsurancesController : ControllerBase
    {
        IDataRepository _data_repository;
        public InsurancesController(IDataRepository dataRepository)
        {
            _data_repository = dataRepository;
        }

        // GET: InsurancesController
        [HttpGet]
        public IEnumerable<Insurance> GetAll()
        {
            return _data_repository.Insurances.GetAll();
           // return new List<Insurance>();
        }
        /*
        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetInsurance(int id)
        {
     
            return _data_repository.Insurance.GetById(id);
        }

         [HttpPost]
        public async Task<IActionResult> CreateInsurance([FromBody] Insurance new_barnd)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInsurance([FromBody] Insurance current_barnd)
        {
            return Ok();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance([FromRoute] int  id)
        {
            return Ok();
        }

        */

    }    
   
}
