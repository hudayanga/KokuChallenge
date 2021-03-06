﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KokuBackend.Business;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KokuBackend_L1.Controllers
{
    [Route("api/[controller]")]
    public class RatesL3Controller : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{amount}")]
        public decimal Get(int amount)
        {
            var rateProcessor = new RateProcessor(amount);
            var bestRate = rateProcessor.GetRatesWithFee();
            return Math.Round(bestRate, 5);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
