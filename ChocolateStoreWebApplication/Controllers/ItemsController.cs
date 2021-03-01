using ChocolateStoreClassLibrary.Models;
using ChocolateStoreClassLibrary.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
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

        public ItemsController()
        {
            repo = MyContainer.provider.GetService<IItemsDBRepository>();
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return repo.GetAll();
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return repo.Find(id);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public string Post(Item item)
        {
            try
            {
                repo.Add(item);
                return "Товар успешно добавлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public string Put(int id, Item item)
        {
            try
            {
                repo.Update(item, id);
                return "Товар успешно обновлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                repo.Delete(id);
                return "Товар успешно обновлен";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
