using ChocolateStoreClassLibrary.Models;
using System.Collections.Generic;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public interface IItemsDBRepository
    {
        List<ItemDto> GetAll();
        void Add(Item item);
        Item Find(int id);
        void Update(Item item, int id);
        void Delete(int id);
    }
}
