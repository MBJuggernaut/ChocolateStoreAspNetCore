using System.Data.Entity;

namespace ChocolateStoreConsoleApp.Models
{
    public class SalesContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public SalesContext() : base("SalesDB")
        {
            Database.SetInitializer(new SalesDbInitializer());
        }
    }
}
