using ChocolateStoreClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public class ItemDBRepository : IItemsDBRepository
    {
        private readonly StoreContext context;
        public ItemDBRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task Add(Item item)
        {
            if (IsValid(item))
            {
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }
            else throw new Exception("Not valid data");
        }

        public async Task Delete(int id)
        {
            var itemtoDelete = await Find(id);
            if (itemtoDelete != null)
            {
                context.Items.Remove(itemtoDelete);
                context.SaveChanges();
            }
            else throw new Exception("Not valid data");
        }

        public async Task<Item> Find(int id)
        {
            var item = context.Items.FindAsync(id);
            return await item;
        }

        public async Task Update(Item item, int id)
        {
            if (IsValid(item))
            {
                var itemToUpdate = await Find(id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = item.Name;
                    itemToUpdate.Price = item.Price;
                    itemToUpdate.Sales = item.Sales;

                    await context.SaveChangesAsync();
                }
            }
            else throw new Exception("Not valid data");
        }

        public async Task<IEnumerable<ItemDto>> GetAll() //мне не нравится избыточность, надо заставить Linq работать
        {
            var allItems = await context.Items.ToListAsync();

            var allItemsAsDto = new List<ItemDto>();
            foreach (var item in allItems)
            {
                allItemsAsDto.Add((ItemDto)item);
            }
            return allItemsAsDto;
        }

        private bool IsValid(Item item)
        {
            return item != null && MyValidator.Validate(item).Count == 0;
        }
    }
}
