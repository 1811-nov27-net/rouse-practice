using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTDemo.Models;

namespace RESTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        // In practice we would use a database, using a static list for demo purposes
        public static List<Temperature> Data = new List<Temperature>();

        // GET: api/Temperature
        [HttpGet]
        // Return type can be just your type, or ActionResult<YourType>; both work, but the latter allows you to return error messages
        public IEnumerable<Temperature> Get()
        {
            return Data;
        }

        // GET: api/Temperature/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Temperature> Get(int id)
        {
            Temperature result =  Data.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return result;

        }

        // POST: api/Temperature
        [HttpPost]
        public ActionResult Post([FromBody] Temperature value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Data.Add(value);
            return Ok();

        }

        // PUT: api/Temperature/5
        // Replace an existing resource
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Temperature value)
        {
            Temperature existing = Data.FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                return NotFound(); // If resource doesn't exist, return an error
            }

            Data.Remove(existing);
            value.Id = id;
            Data.Add(value);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Temperature existing = Data.FirstOrDefault(x => x.Id == id);

            if (existing == null)
            {
                return NotFound(); // If resource doesn't exist, return an error
            }

            Data.Remove(existing);

            return Ok();
        }
    }
}
