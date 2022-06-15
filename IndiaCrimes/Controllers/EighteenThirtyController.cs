using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EighteenThirtyController : ControllerBase
    {
        // GET: api/<EighteenThirtyController>
        [HttpGet]
        public IEnumerable<EighteenThirtyTable> Get()
        {
            var context = new Models.IndiaCrimeDBContext();
            return context.EighteenThirtyTables.ToList();
        }

        // GET api/<EighteenThirtyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EighteenThirtyController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<EighteenThirtyController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EighteenThirtyController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
