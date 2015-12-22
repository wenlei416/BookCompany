namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdeliveryorder2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDeliveryOrder",
                c => new
                    {
                        BookDeliveryOrderId = c.Int(nullable: false, identity: true),
                        BookDeliveryOrderName = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                        PrintShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookDeliveryOrderId)
                .ForeignKey("dbo.PrintShop", t => t.PrintShopId, cascadeDelete: true)
                .Index(t => t.PrintShopId);
            
            AddColumn("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId", c => c.Int());
            CreateIndex("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId");
            AddForeignKey("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId", "dbo.BookDeliveryOrder", "BookDeliveryOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookDeliveryOrder", "PrintShopId", "dbo.PrintShop");
            DropForeignKey("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId", "dbo.BookDeliveryOrder");
            DropIndex("dbo.BookDeliveryOrder", new[] { "PrintShopId" });
            DropIndex("dbo.BookDelivery", new[] { "BookDeliveryOrder_BookDeliveryOrderId" });
            DropColumn("dbo.BookDelivery", "BookDeliveryOrder_BookDeliveryOrderId");
            DropTable("dbo.BookDeliveryOrder");
        }
    }
}
