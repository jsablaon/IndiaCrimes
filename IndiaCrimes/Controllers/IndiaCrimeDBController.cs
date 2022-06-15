using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndiaCrimeDBController : ControllerBase
    {
        // GET: api/<IndiaCrimeDBController>
        [HttpGet]
        public List<string> Get()
        {
            // TODO: main queries
            return new List<string> { "india", "Cimes", "table" };
        }

        // GET api/<IndiaCrimeDBController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        //[ActionName("GetNumberOfProperties")]
        public List<string> GetNumberOfProperties(int pYear)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetNumberOfProperties: ${pYear}+++++++++++++++++++++++++++++");
            // TODO: main queries
            return new List<string> { "india", "Cimes", "table" };
        }

        //[HttpGet]
        //[ActionName("GetValueProperties")]
        //[HttpGet("{IndiaCrimeDB}/GetValueProperties")]
        //[Route("GetValueProperties/{id:string}")]

        [Route("IndiaCrimesDB/GetValueProperties")]
        [HttpGet]
        public int GetValueProperties(string pLocation)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetValueProperties: ${pLocation}+++++++++++++++++++++++++++++");
            // TODO: main queries
            var context = new IndiaCrimeDBContext();
            var totalQuery = (from eachOrder in context.CrimeFactTables
                              where eachOrder.Location == pLocation
                              select eachOrder.PrecovId).Sum();

            return totalQuery;
        }

        [HttpGet]
        //[ActionName("GetGenderData")]
        public List<string> GetGenderData(int pGenderId)
        {
            System.Diagnostics.Debug.WriteLine($"++++++++++++++++++++++GetGenderData: ${pGenderId}+++++++++++++++++++++++++++++");
            // TODO: main queries
            return new List<string> { pGenderId.ToString() };
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
