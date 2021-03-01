namespace ChocolateStoreClassLibrary.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string SaleDate { get; set; }

        public static explicit operator SaleDto(Sale sale)
        {
            return new SaleDto { Id = sale.Id, SaleDate = sale.SaleDate.ToString("T") };
        }
    }
}
