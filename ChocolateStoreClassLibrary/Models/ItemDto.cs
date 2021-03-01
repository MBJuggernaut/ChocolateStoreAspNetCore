using System.Collections.Generic;

namespace ChocolateStoreClassLibrary.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<SaleDto> Sales { get; set; }

        public static explicit operator ItemDto(Item item)
        {
            var idto= new ItemDto { Id = item.Id, Name = item.Name, Price = item.Price, Sales = new List<SaleDto>() };

            foreach (var sale in item.Sales)
            {
                idto.Sales.Add((SaleDto)sale);
            }

            return idto;
        }
    }
}
