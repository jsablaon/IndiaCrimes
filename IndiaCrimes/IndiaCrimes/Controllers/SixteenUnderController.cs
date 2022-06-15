using Microsoft.AspNetCore.Mvc;
using IndiaCrimes.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiaCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SixteenUnderController : ControllerBase
    {
        // GET: api/<SixteenUnderController>
        [HttpGet]
        public IEnumerable<SixteenUnderTable> Get()
        {
            var context = new Models.IndiaCrimeDBContext();
            return context.SixteenUnderTables.ToList();
        }

        // GET api/<SixteenUnderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SixteenUnderController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SixteenUnderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SixteenUnderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
