using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChocolateStoreClassLibrary.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime SaleDate { get; set; }
        public virtual List<Item> Items { get; set; }

        public Sale()
        {
            SaleDate = DateTime.Now;           
        }
    }
}
