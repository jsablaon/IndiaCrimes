using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalFactController : ControllerBase
    {
        // GET: api/<CriminalFactController>
        [HttpGet]
        public IEnumerable<CriminalFactTable> Get()
        {
            var context = new Models.IndiaCrimeDBContext();
            return context.CriminalFactTables.ToList();
        }

        // GET api/<CriminalFactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CriminalFactController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CriminalFactController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CriminalFactController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
