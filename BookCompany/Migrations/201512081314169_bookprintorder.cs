namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookprintorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookPrintOrder", "PrintNo", c => c.String());
            AddColumn("dbo.BookPrintOrder", "PageFormat", c => c.Int(nullable: false));
            AddColumn("dbo.BookPrintOrder", "PageSize", c => c.String());
            AddColumn("dbo.BookPrintOrder", "Printsheet", c => c.Single(nullable: false));
            AddColumn("dbo.BookPrintOrder", "Bookbinding", c => c.String());
            AddColumn("dbo.BookPrintOrder", "Plasticpackage", c => c.String());
            AddColumn("dbo.BookPrintOrder", "Normalpackage", c => c.Int(nullable: false));
            AddColumn("dbo.BookPrintOrder", "Railpackage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookPrintOrder", "Railpackage");
            DropColumn("dbo.BookPrintOrder", "Normalpackage");
            DropColumn("dbo.BookPrintOrder", "Plasticpackage");
            DropColumn("dbo.BookPrintOrder", "Bookbinding");
            DropColumn("dbo.BookPrintOrder", "Printsheet");
            DropColumn("dbo.BookPrintOrder", "PageSize");
            DropColumn("dbo.BookPrintOrder", "PageFormat");
            DropColumn("dbo.BookPrintOrder", "PrintNo");
        }
    }
}
