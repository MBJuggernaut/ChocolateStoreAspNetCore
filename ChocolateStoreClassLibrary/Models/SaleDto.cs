namespace ChocolateStoreClassLibrary.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string SaleDate { get; set; }

        public static explicit operator SaleDto(Sale v)
        {
            return new SaleDto { Id = v.Id, SaleDate = v.SaleDate.ToString("T") };
        }
    }
}
