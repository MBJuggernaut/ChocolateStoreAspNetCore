using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ChocolateStoreConsoleApp.Models
{
    public class SalesDbInitializer : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            Item item1 = new Item { Id = 1, Name = "Шоколадка 'Аленка' 90гр.", Price = 40 };
            Item item2 = new Item { Id = 2, Name = "Шоколадка 'Аленка' 150гр.", Price = 60 };
            
            Sale sale = new Sale { Id = 1, Items = new List<Item> { item1, item2 } };
            context.Sales.Add(sale);
        }
    }
}
