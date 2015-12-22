namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdeliveryorder3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookDelivery", "BookPrintOrderId", "dbo.BookPrintOrder");
            DropIndex("dbo.BookDelivery", new[] { "BookPrintOrderId" });
            RenameColumn(table: "dbo.BookDelivery", name: "BookDeliveryOrder_BookDeliveryOrderId", newName: "BookDeliveryOrderId");
            RenameIndex(table: "dbo.BookDelivery", name: "IX_BookDeliveryOrder_BookDeliveryOrderId", newName: "IX_BookDeliveryOrderId");
            AddColumn("dbo.BookDelivery", "BookDeliveryOrder_BookPrintOrderId", c => c.Int());
            AddColumn("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId", c => c.Int());
            AddColumn("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId1", c => c.Int());
            AddColumn("dbo.BookDeliveryOrder", "BookEditonId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookDelivery", "BookDeliveryOrder_BookPrintOrderId");
            CreateIndex("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId");
            CreateIndex("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId1");
            CreateIndex("dbo.BookDeliveryOrder", "BookEditonId");
            AddForeignKey("dbo.BookDelivery", "BookDeliveryOrder_BookPrintOrderId", "dbo.BookPrintOrder", "BookPrintOrderId");
            AddForeignKey("dbo.BookDeliveryOrder", "BookEditonId", "dbo.BookEditon", "BookEditonId", cascadeDelete: true);
            AddForeignKey("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId1", "dbo.BookPrintOrder", "BookPrintOrderId");
            AddForeignKey("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId", "dbo.BookPrintOrder", "BookPrintOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId", "dbo.BookPrintOrder");
            DropForeignKey("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId1", "dbo.BookPrintOrder");
            DropForeignKey("dbo.BookDeliveryOrder", "BookEditonId", "dbo.BookEditon");
            DropForeignKey("dbo.BookDelivery", "BookDeliveryOrder_BookPrintOrderId", "dbo.BookPrintOrder");
            DropIndex("dbo.BookDeliveryOrder", new[] { "BookEditonId" });
            DropIndex("dbo.BookDelivery", new[] { "BookPrintOrder_BookPrintOrderId1" });
            DropIndex("dbo.BookDelivery", new[] { "BookPrintOrder_BookPrintOrderId" });
            DropIndex("dbo.BookDelivery", new[] { "BookDeliveryOrder_BookPrintOrderId" });
            DropColumn("dbo.BookDeliveryOrder", "BookEditonId");
            DropColumn("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId1");
            DropColumn("dbo.BookDelivery", "BookPrintOrder_BookPrintOrderId");
            DropColumn("dbo.BookDelivery", "BookDeliveryOrder_BookPrintOrderId");
            RenameIndex(table: "dbo.BookDelivery", name: "IX_BookDeliveryOrderId", newName: "IX_BookDeliveryOrder_BookDeliveryOrderId");
            RenameColumn(table: "dbo.BookDelivery", name: "BookDeliveryOrderId", newName: "BookDeliveryOrder_BookDeliveryOrderId");
            CreateIndex("dbo.BookDelivery", "BookPrintOrderId");
            AddForeignKey("dbo.BookDelivery", "BookPrintOrderId", "dbo.BookPrintOrder", "BookPrintOrderId");
        }
    }
}
