namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paperneed1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PaperNeed", "PaperCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaperNeed", "PaperCount", c => c.Single(nullable: false));
        }
    }
}
