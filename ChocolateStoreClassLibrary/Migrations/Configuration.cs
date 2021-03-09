namespace ChocolateStoreClassLibrary.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ChocolateStoreClassLibrary.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ChocolateStoreClassLibrary.Models.StoreContext";
        }

        protected override void Seed(ChocolateStoreClassLibrary.Models.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
