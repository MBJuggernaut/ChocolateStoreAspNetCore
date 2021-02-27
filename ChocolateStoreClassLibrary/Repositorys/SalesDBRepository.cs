using ChocolateStoreConsoleApp.Models;
using System;
using System.Linq;

namespace ChocolateStoreConsoleApp.Repositorys
{
    public class SalesDBRepository : ISalesDBRepository
    {
        private SalesContext context;
        public SalesDBRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Add(Sale sale)
        {
            if (IsValid(sale))
            {
                context.Sales.Add(sale);
                context.SaveChanges();
            }
            else throw new Exception("Not valid data");
        }
        public void Delete(int id)
        {
            var saletoDelete = Find(id);
            if (saletoDelete != null)
            {
                context.Sales.Remove(saletoDelete);
                context.SaveChanges();
            }
        }
        public Sale Find(int id)
        {
            return context.Sales.FirstOrDefault(t => t.Id == id);
        }


        private bool IsValid(Sale sale)
        {
            return sale != null && sale.Items.Count > 0 && MyValidator.Validate(sale).Count == 0;
        }
    }
}
