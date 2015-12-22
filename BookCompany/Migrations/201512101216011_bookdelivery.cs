namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookdelivery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDelivery",
                c => new
                    {
                        BookDeliveryId = c.Int(nullable: false, identity: true),
                        DeliveryType = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryQuantily = c.Int(nullable: false),
                        DeliveryAddress = c.String(),
                        DeliveryContact = c.String(),
                        BookPrintOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.BookDeliveryId)
                .ForeignKey("dbo.BookPrintOrder", t => t.BookPrintOrderId)
                .Index(t => t.BookPrintOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookDelivery", "BookPrintOrderId", "dbo.BookPrintOrder");
            DropIndex("dbo.BookDelivery", new[] { "BookPrintOrderId" });
            DropTable("dbo.BookDelivery");
        }
    }
}
