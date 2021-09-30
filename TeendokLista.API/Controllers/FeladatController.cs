using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeendokLista.Data.Models;
using TeendokLista.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeendokLista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeladatController : ControllerBase
    {
        FeladatRepository repo = new FeladatRepository();
        // GET: api/<FeladatController>
        [HttpGet]
        public IEnumerable<Feladat> Get()
        {
            return repo.GetAll();
        }

        // GET api/<FeladatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FeladatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FeladatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeladatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
