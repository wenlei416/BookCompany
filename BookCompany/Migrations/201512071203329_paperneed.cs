namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paperneed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaperNeed", "PageType", c => c.Int(nullable: false));
            AddColumn("dbo.PaperNeed", "PaperFormat", c => c.Int(nullable: false));
            AddColumn("dbo.PaperNeed", "Need", c => c.Single(nullable: false));
            AddColumn("dbo.PaperNeed", "PaperWastage", c => c.Single(nullable: false));
            AddColumn("dbo.PaperNeed", "PaperCount", c => c.Single(nullable: false));
            AddColumn("dbo.PaperNeed", "Technological", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaperNeed", "Technological");
            DropColumn("dbo.PaperNeed", "PaperCount");
            DropColumn("dbo.PaperNeed", "PaperWastage");
            DropColumn("dbo.PaperNeed", "Need");
            DropColumn("dbo.PaperNeed", "PaperFormat");
            DropColumn("dbo.PaperNeed", "PageType");
        }
    }
}
