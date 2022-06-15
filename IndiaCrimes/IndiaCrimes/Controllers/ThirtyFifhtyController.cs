using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThirtyFifhtyController : ControllerBase
    {
        // GET: api/<ThirtyFifhtyController>
        [HttpGet]
        public IEnumerable<ThirtyFithtyTable> Get()
        {
            var context = new Models.IndiaCrimeDBContext();
            return context.ThirtyFithtyTables.ToList();
        }

        // GET api/<ThirtyFifhtyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThirtyFifhtyController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ThirtyFifhtyController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ThirtyFifhtyController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
