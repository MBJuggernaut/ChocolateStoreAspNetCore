using ChocolateStoreClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public interface IItemsDBRepository
    {
        Task<IEnumerable<ItemDto>> GetAll();
        Task Add(Item item);
        Task<Item> Find(int id);
        Task Update(Item item, int id);
        Task Delete(int id);
    }
}
