namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdeliveryorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId", "dbo.BookDeliveryOrder");
            DropForeignKey("dbo.BookDeliveryOrder", "PrintShopId", "dbo.PrintShop");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookDeliveryOrder",
                c => new
                    {
                        BookDeliveryOrderId = c.Int(nullable: false, identity: true),
                        BookDeliveryOrderrName = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        PrintShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookDeliveryOrderId);
            
            AddColumn("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId", c => c.Int());
            CreateIndex("dbo.BookDeliveryOrder", "PrintShopId");
            CreateIndex("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId");
            AddForeignKey("dbo.BookDeliveryOrder", "PrintShopId", "dbo.PrintShop", "PrintShopId", cascadeDelete: true);
            AddForeignKey("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId", "dbo.BookDeliveryOrder", "BookDeliveryOrderId");
        }
    }
}
