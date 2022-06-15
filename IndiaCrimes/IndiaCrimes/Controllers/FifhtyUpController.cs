using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FifhtyUpController : ControllerBase
    {
        // GET: api/<FifhtyUpController>
        [HttpGet]
        public IEnumerable<FithtyUpTable> Get()
        {
            var context = new Models.IndiaCrimeDBContext();
            return context.FithtyUpTables.ToList();
        }

        // GET api/<FifhtyUpController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FifhtyUpController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<FifhtyUpController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FifhtyUpController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
