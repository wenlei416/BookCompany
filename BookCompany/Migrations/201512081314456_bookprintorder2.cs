namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookprintorder2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookPrintOrder", "Paper_PaperId", "dbo.Paper");
            DropIndex("dbo.BookPrintOrder", new[] { "Paper_PaperId" });
            DropColumn("dbo.BookPrintOrder", "Paper_PaperId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookPrintOrder", "Paper_PaperId", c => c.Int());
            CreateIndex("dbo.BookPrintOrder", "Paper_PaperId");
            AddForeignKey("dbo.BookPrintOrder", "Paper_PaperId", "dbo.Paper", "PaperId");
        }
    }
}
