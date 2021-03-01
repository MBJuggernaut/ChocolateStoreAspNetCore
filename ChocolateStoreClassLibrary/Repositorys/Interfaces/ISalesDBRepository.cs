using ChocolateStoreClassLibrary.Models;
using System.Collections.Generic;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public interface ISalesDBRepository
    {
        IEnumerable<SaleDto> GetAll();
        void Add(Sale sale);
        Sale Find(int id);        
        void Delete(int id);
    }
}
