using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndiaCrimeDBController : ControllerBase
    {
        // GET: api/<IndiaCrimeDBController>
        [HttpGet]
        [ActionName("Get")]
        public List<string> Get()
        {
            // TODO: main queries
            return new List<string> { "india", "Cimes", "table" };
        }

        [HttpGet("{pYear}")]
        [ActionName("GetNumberOfProperties")]
        public int GetNumberOfProperties(int pYear)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetNumberOfProperties: {pYear}+++++++++++++++++++++++++++++");
            // TODO: main queries
            return pYear;
        }

        [HttpGet("{pLocation}")]
        [ActionName("GetValueProperties")]
        public int GetValueProperties(string pLocation)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: {pLocation} +++++++++++++++++++++++++++++");
            // TODO: main queries
            var context = new IndiaCrimeDBContext();
            var totalQuery = (from eachOrder in context.CrimeFactTables
                              where eachOrder.Location == pLocation
                              select eachOrder.PrecovId).Sum();

            return totalQuery;
        }

        [HttpGet("{pGenderId}")]
        [ActionName("GetGenderData")]
        public int GetGenderData(int pGenderId)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetGenderData: {pGenderId}+++++++++++++++++++++++++++++");
            // TODO: main queries
            return pGenderId;
        }

        // POST api/<IndiaCrimeDBController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<IndiaCrimeDBController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<IndiaCrimeDBController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
