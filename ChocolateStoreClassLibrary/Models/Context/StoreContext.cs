using System.Data.Entity;

namespace ChocolateStoreClassLibrary.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public StoreContext() : base("StoreDB")
        {
            Database.SetInitializer(new Seeder());
        }
    }
}
