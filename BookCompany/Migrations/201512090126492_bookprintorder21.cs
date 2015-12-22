namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookprintorder21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Makeup", "BookPrintOrder_BookPrintOrderId", "dbo.BookPrintOrder");
            DropIndex("dbo.Makeup", new[] { "BookPrintOrder_BookPrintOrderId" });
            RenameColumn(table: "dbo.Makeup", name: "BookPrintOrder_BookPrintOrderId", newName: "BookPrintOrderId");
            AlterColumn("dbo.Makeup", "BookPrintOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Makeup", "BookPrintOrderId");
            AddForeignKey("dbo.Makeup", "BookPrintOrderId", "dbo.BookPrintOrder", "BookPrintOrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Makeup", "BookPrintOrderId", "dbo.BookPrintOrder");
            DropIndex("dbo.Makeup", new[] { "BookPrintOrderId" });
            AlterColumn("dbo.Makeup", "BookPrintOrderId", c => c.Int());
            RenameColumn(table: "dbo.Makeup", name: "BookPrintOrderId", newName: "BookPrintOrder_BookPrintOrderId");
            CreateIndex("dbo.Makeup", "BookPrintOrder_BookPrintOrderId");
            AddForeignKey("dbo.Makeup", "BookPrintOrder_BookPrintOrderId", "dbo.BookPrintOrder", "BookPrintOrderId");
        }
    }
}
