using ChocolateStoreConsoleApp.Models;

namespace ChocolateStoreConsoleApp.Repositorys
{
    public interface ISalesDBRepository
    {
        void Add(Sale sale);
        Sale Find(int id);
        void Update(Sale sale, int id);
        void Delete(int id);
    }
}
