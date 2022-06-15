using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyStolenController : ControllerBase
    {
        // GET: api/<PropertyStolenController>
        [HttpGet]
        public IEnumerable<PropertyStolenTable> Get()
        {
            var context = new Models.IndiaCrimeDBContext();
            return context.PropertyStolenTables.ToList();
        }

        // GET api/<PropertyStolenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropertyStolenController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PropertyStolenController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PropertyStolenController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
