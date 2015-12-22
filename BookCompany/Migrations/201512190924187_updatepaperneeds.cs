namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepaperneeds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PaperNeed", "PaperNeedMount", c => c.Single(nullable: false));
            AlterColumn("dbo.PaperInstock", "PaperMount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaperInstock", "PaperMount", c => c.Int(nullable: false));
            AlterColumn("dbo.PaperNeed", "PaperNeedMount", c => c.Int(nullable: false));
        }
    }
}
