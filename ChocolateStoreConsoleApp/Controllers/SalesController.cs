using ChocolateStoreClassLibrary.Models;
using ChocolateStoreClassLibrary.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChocolateStoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesDBRepository repo;

        public SalesController(ISalesDBRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/<SalesController>
        [HttpGet]
        public async Task<IEnumerable<SaleDto>> Get()
        {
            return await repo.GetAll();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> Get(int id)
        {
            var sale = await repo.Find(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<IActionResult> Post(Sale sale)
        {
            try
            {
                await repo.Add(sale);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repo.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
