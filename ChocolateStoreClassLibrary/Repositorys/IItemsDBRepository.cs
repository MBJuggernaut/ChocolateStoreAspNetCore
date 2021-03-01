using ChocolateStoreClassLibrary.Models;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public interface IItemsDBRepository
    {
        void Add(Item item);
        Item Find(int id);
        void Update(Item item, int id);
        void Delete(int id);
    }
}
