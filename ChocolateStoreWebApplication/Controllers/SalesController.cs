using ChocolateStoreClassLibrary.Models;
using ChocolateStoreClassLibrary.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChocolateStoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesDBRepository repo;

        public SalesController()
        {
            repo = MyContainer.provider.GetService<ISalesDBRepository>();
        }
        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<SaleDto> Get()
        {
            return repo.GetAll();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
