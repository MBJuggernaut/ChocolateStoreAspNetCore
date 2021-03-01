﻿using ChocolateStoreClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public class SalesDBRepository : ISalesDBRepository
    {
        private readonly StoreContext context;
        public SalesDBRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task Add(Sale sale)
        {
            if (IsValid(sale))
            {
                context.Sales.Add(sale);
                await context.SaveChangesAsync();
            }
            else throw new Exception();
        }
        public async Task Delete(int id)
        {
            var saletoDelete = await Find(id);
            if (saletoDelete != null)
            {
                context.Sales.Remove(saletoDelete);
                context.SaveChanges();
            }
            else throw new Exception();
        }
        public async Task<Sale> Find(int id)
        {
            return await context.Sales.FindAsync(id);
        }

        public async Task<IEnumerable<SaleDto>> GetAll()
        {
            var allSales = await context.Sales.ToListAsync();

            var allSalesAsDto = new List<SaleDto>();
            foreach (var sale in allSales)
            {
                allSalesAsDto.Add((SaleDto)sale);
            }
            return allSalesAsDto;
        }

        private bool IsValid(Sale sale)
        {
            return sale != null && sale.Items.Count > 0 && MyValidator.Validate(sale).Count == 0;
        }
    }
}
