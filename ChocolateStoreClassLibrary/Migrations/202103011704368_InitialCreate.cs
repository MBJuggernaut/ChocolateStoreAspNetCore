namespace ChocolateStoreClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleItems",
                c => new
                    {
                        Sale_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sale_Id, t.Item_Id })
                .ForeignKey("dbo.Sales", t => t.Sale_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Sale_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.SaleItems", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.SaleItems", new[] { "Item_Id" });
            DropIndex("dbo.SaleItems", new[] { "Sale_Id" });
            DropTable("dbo.SaleItems");
            DropTable("dbo.Sales");
            DropTable("dbo.Items");
        }
    }
}
