using ChocolateStoreClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public interface IItemsDBRepository
    {
        Task<IEnumerable<ItemDto>> GetAll();
        void Add(Item item);
        Item Find(int id);
        void Update(Item item, int id);
        void Delete(int id);
    }
}
