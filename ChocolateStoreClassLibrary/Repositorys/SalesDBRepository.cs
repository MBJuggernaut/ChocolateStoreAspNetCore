﻿using ChocolateStoreClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChocolateStoreClassLibrary.Repositorys
{
    public class SalesDBRepository : ISalesDBRepository
    {
        private readonly StoreContext context;
        public SalesDBRepository(StoreContext context)
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

        public IEnumerable<SaleDto> GetAll()
        {
            var allSales = context.Sales.ToList();

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
