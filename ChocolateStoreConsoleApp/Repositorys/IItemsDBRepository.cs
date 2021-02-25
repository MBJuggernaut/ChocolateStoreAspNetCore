using ChocolateStoreConsoleApp.Models;

namespace ChocolateStoreConsoleApp.Repositorys
{
    public interface IItemsDBRepository
    {
        void Add(Item item);
        Item Find(int id);
        void Update(Item item, int id);
        void Delete(int id);
    }
}
