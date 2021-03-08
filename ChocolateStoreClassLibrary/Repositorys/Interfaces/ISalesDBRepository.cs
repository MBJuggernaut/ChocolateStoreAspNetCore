using ChocolateStoreClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public interface ISalesDBRepository
    {
        Task<IEnumerable<SaleDto>> GetAll();
        Task Add(Sale sale);
        Task<Sale> Find(int id);        
        Task Delete(int id);
        Task<int> GetReport();
    }
}
