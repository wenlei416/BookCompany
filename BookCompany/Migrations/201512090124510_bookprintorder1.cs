namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookprintorder1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Makeup",
                c => new
                    {
                        MakeupId = c.Int(nullable: false, identity: true),
                        MakeupName = c.String(),
                        MakeupType = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        BookPrintOrder_BookPrintOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.MakeupId)
                .ForeignKey("dbo.BookPrintOrder", t => t.BookPrintOrder_BookPrintOrderId)
                .Index(t => t.BookPrintOrder_BookPrintOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Makeup", "BookPrintOrder_BookPrintOrderId", "dbo.BookPrintOrder");
            DropIndex("dbo.Makeup", new[] { "BookPrintOrder_BookPrintOrderId" });
            DropTable("dbo.Makeup");
        }
    }
}
