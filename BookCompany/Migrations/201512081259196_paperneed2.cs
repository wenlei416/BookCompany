namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paperneed2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PaperNeed", "PaperNeedName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaperNeed", "PaperNeedName", c => c.String());
        }
    }
}
