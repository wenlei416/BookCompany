namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookedition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookInstock", "BookId", "dbo.Book");
            DropIndex("dbo.BookInstock", new[] { "BookId" });
            AddColumn("dbo.BookInstock", "BookEditonId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookInstock", "BookEditonId");
            AddForeignKey("dbo.BookInstock", "BookEditonId", "dbo.BookEditon", "BookEditonId", cascadeDelete: true);
            DropColumn("dbo.BookInstock", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookInstock", "BookId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookInstock", "BookEditonId", "dbo.BookEditon");
            DropIndex("dbo.BookInstock", new[] { "BookEditonId" });
            DropColumn("dbo.BookInstock", "BookEditonId");
            CreateIndex("dbo.BookInstock", "BookId");
            AddForeignKey("dbo.BookInstock", "BookId", "dbo.Book", "BookId", cascadeDelete: true);
        }
    }
}
