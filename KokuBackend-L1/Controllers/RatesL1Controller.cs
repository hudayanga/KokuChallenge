using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KokuBackend.Business;
using Microsoft.AspNetCore.Mvc;

namespace KokuBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesL1Controller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{amount}")]
        public ActionResult<decimal> Get(int amount)
        {
            var rateProcessor = new RateProcessor();
            var bestRate = rateProcessor.FindBestRate(amount);
            return Math.Round(bestRate,5);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
