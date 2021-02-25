using ChocolateStoreConsoleApp.Models;
using System;
using System.Linq;

namespace ChocolateStoreConsoleApp.Repositorys
{
    public class ItemDBRepository : IItemsDBRepository
    {
        private SalesContext context;
        public ItemDBRepository(SalesContext context)
        {
            this.context = context;
        }
        public void Add(Item item)
        {
            if (IsValid(item))
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var itemtoDelete = Find(id);
            if (itemtoDelete != null)
            {
                context.Items.Remove(itemtoDelete);
                context.SaveChanges();
            }
        }

        public Item Find(int id)
        {
            return context.Items.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Item item, int id)
        {
            if (IsValid(item))
            {
                var itemToUpdate = Find(id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Name = item.Name;
                    itemToUpdate.Price = item.Price;
                    itemToUpdate.Sales = item.Sales; //???

                    context.SaveChanges();
                }
            }
        }

        private bool IsValid(Item item)
        {
            return MyValidator.Validate(item).Count == 0 && item != null;
        }
    }
}
