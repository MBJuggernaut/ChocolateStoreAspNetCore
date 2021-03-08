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
    public class ItemsController : ControllerBase
    {
        private readonly IItemsDBRepository repo;

        public ItemsController(IItemsDBRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> Get()
        {
            return await repo.GetAll();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {          
            var item = await repo.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<IActionResult> Post(Item item)
        {
            try
            {
                await repo.Add(item);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Item item)
        {
            try
            {
                await repo.Update(item, id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/<ItemsController>/5
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
