using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeFactController : ControllerBase
    {
        // GET: api/<CrimeFactController>
        [HttpGet]
        public IEnumerable<CrimeFactTable> Get()
        {
            System.Diagnostics.Debug.WriteLine("+++++++++++++++++++crime fact get method++++++++++++++++++++++");
            var context = new Models.IndiaCrimeDBContext();
            return context.CrimeFactTables.ToList();
        }

        // GET api/<CrimeFactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<CrimeFactController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CrimeFactController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CrimeFactController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
