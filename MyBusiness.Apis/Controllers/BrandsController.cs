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
    public class BrandsController : ControllerBase
    {
        IDataRepository _data_repository;
        public BrandsController(IDataRepository dataRepository)
        {
            _data_repository = dataRepository;
        }

        // GET: BrandsController
        [HttpGet]
        public IEnumerable<Brand> GetAll()
        {
            return _data_repository.Brand.GetAll();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] Brand new_barnd)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] Brand new_barnd)
        {
            return Ok();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand([FromRoute] int  id)
        {
            return Ok();
        }

    }    
   
}
