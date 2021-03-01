using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChocolateStoreClassLibrary.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле названия не должно оставаться пустым. Название товара может содержать от 1 до 100 символов.")]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }
        
        public virtual List<Sale> Sales { get; set; }

        public Item()
        {
            Sales = new List<Sale>();
        }
    }
}
