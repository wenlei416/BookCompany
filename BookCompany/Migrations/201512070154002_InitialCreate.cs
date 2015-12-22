namespace BookCompanyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCompany",
                c => new
                    {
                        BookCompanyId = c.Int(nullable: false, identity: true),
                        BookCompanyName = c.String(),
                        BookCompanyDescription = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookCompanyId);
            
            CreateTable(
                "dbo.BookPrintOrder",
                c => new
                    {
                        BookPrintOrderId = c.Int(nullable: false, identity: true),
                        BookPrintOrderName = c.String(),
                        BookPrintMount = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        CopmleteDateTime = c.DateTime(),
                        BookEditonId = c.Int(nullable: false),
                        BookCompanyId = c.Int(nullable: false),
                        PrintShopId = c.Int(nullable: false),
                        Paper_PaperId = c.Int(),
                    })
                .PrimaryKey(t => t.BookPrintOrderId)
                .ForeignKey("dbo.BookCompany", t => t.BookCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.BookEditon", t => t.BookEditonId, cascadeDelete: true)
                .ForeignKey("dbo.PrintShop", t => t.PrintShopId, cascadeDelete: true)
                .ForeignKey("dbo.Paper", t => t.Paper_PaperId)
                .Index(t => t.BookEditonId)
                .Index(t => t.BookCompanyId)
                .Index(t => t.PrintShopId)
                .Index(t => t.Paper_PaperId);
            
            CreateTable(
                "dbo.BookEditon",
                c => new
                    {
                        BookEditonId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        PublishingHouse = c.String(),
                        ISBN = c.String(),
                        BookPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Edtion = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookEditonId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        PublishingHouse = c.String(),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Paper",
                c => new
                    {
                        PaperId = c.Int(nullable: false, identity: true),
                        PaperName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        PaperBrandId = c.Int(nullable: false),
                        PaperSpecId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperId)
                .ForeignKey("dbo.PaperBrand", t => t.PaperBrandId, cascadeDelete: true)
                .ForeignKey("dbo.PaperSpec", t => t.PaperSpecId, cascadeDelete: true)
                .Index(t => t.PaperBrandId)
                .Index(t => t.PaperSpecId);
            
            CreateTable(
                "dbo.PaperBrand",
                c => new
                    {
                        PaperBrandId = c.Int(nullable: false, identity: true),
                        PaperBrandName = c.String(),
                        PaperMillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperBrandId)
                .ForeignKey("dbo.PaperMill", t => t.PaperMillId, cascadeDelete: true)
                .Index(t => t.PaperMillId);
            
            CreateTable(
                "dbo.PaperMill",
                c => new
                    {
                        PaperMillId = c.Int(nullable: false, identity: true),
                        PaperMillName = c.String(),
                    })
                .PrimaryKey(t => t.PaperMillId);
            
            CreateTable(
                "dbo.PaperSpec",
                c => new
                    {
                        PaperSpecId = c.Int(nullable: false, identity: true),
                        PaperSpecName = c.String(),
                        PaperType = c.String(),
                        PaperWeight = c.String(),
                        PaperSize = c.String(),
                        PaperDescription = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaperSpecId);
            
            CreateTable(
                "dbo.PaperInstock",
                c => new
                    {
                        PaperInstockId = c.Int(nullable: false, identity: true),
                        PaperInstockNname = c.String(),
                        PaperMount = c.Int(nullable: false),
                        PaperId = c.Int(nullable: false),
                        PrintShopId = c.Int(nullable: false),
                        PaperSpec_PaperSpecId = c.Int(),
                    })
                .PrimaryKey(t => t.PaperInstockId)
                .ForeignKey("dbo.Paper", t => t.PaperId, cascadeDelete: true)
                .ForeignKey("dbo.PrintShop", t => t.PrintShopId, cascadeDelete: true)
                .ForeignKey("dbo.PaperSpec", t => t.PaperSpec_PaperSpecId)
                .Index(t => t.PaperId)
                .Index(t => t.PrintShopId)
                .Index(t => t.PaperSpec_PaperSpecId);
            
            CreateTable(
                "dbo.PrintShop",
                c => new
                    {
                        PrintShopId = c.Int(nullable: false, identity: true),
                        PrintShopName = c.String(),
                        PrintShopDescription = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrintShopId);
            
            CreateTable(
                "dbo.PaperMakingOrder",
                c => new
                    {
                        PaperMakingOrderId = c.Int(nullable: false, identity: true),
                        PaperMakingOrderName = c.String(),
                        PaperMount = c.Int(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                        CopmleteDateTime = c.DateTime(),
                        BookCompanyId = c.Int(nullable: false),
                        PaperId = c.Int(nullable: false),
                        PrintShopId = c.Int(nullable: false),
                        PaperSpec_PaperSpecId = c.Int(),
                    })
                .PrimaryKey(t => t.PaperMakingOrderId)
                .ForeignKey("dbo.BookCompany", t => t.BookCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Paper", t => t.PaperId, cascadeDelete: true)
                .ForeignKey("dbo.PrintShop", t => t.PrintShopId, cascadeDelete: true)
                .ForeignKey("dbo.PaperSpec", t => t.PaperSpec_PaperSpecId)
                .Index(t => t.BookCompanyId)
                .Index(t => t.PaperId)
                .Index(t => t.PrintShopId)
                .Index(t => t.PaperSpec_PaperSpecId);
            
            CreateTable(
                "dbo.PaperNeed",
                c => new
                    {
                        PaperNeedId = c.Int(nullable: false, identity: true),
                        PaperNeedName = c.String(),
                        PaperId = c.Int(nullable: false),
                        PaperNeedMount = c.Int(nullable: false),
                        BookPrintOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaperNeedId)
                .ForeignKey("dbo.BookPrintOrder", t => t.BookPrintOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Paper", t => t.PaperId, cascadeDelete: true)
                .Index(t => t.PaperId)
                .Index(t => t.BookPrintOrderId);
            
            CreateTable(
                "dbo.BookInstock",
                c => new
                    {
                        BookInstockId = c.Int(nullable: false, identity: true),
                        BookInstockNname = c.String(),
                        BookMount = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        PrintShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookInstockId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.PrintShop", t => t.PrintShopId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.PrintShopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookInstock", "PrintShopId", "dbo.PrintShop");
            DropForeignKey("dbo.BookInstock", "BookId", "dbo.Book");
            DropForeignKey("dbo.PaperNeed", "PaperId", "dbo.Paper");
            DropForeignKey("dbo.PaperNeed", "BookPrintOrderId", "dbo.BookPrintOrder");
            DropForeignKey("dbo.BookPrintOrder", "Paper_PaperId", "dbo.Paper");
            DropForeignKey("dbo.Paper", "PaperSpecId", "dbo.PaperSpec");
            DropForeignKey("dbo.PaperMakingOrder", "PaperSpec_PaperSpecId", "dbo.PaperSpec");
            DropForeignKey("dbo.PaperInstock", "PaperSpec_PaperSpecId", "dbo.PaperSpec");
            DropForeignKey("dbo.PaperMakingOrder", "PrintShopId", "dbo.PrintShop");
            DropForeignKey("dbo.PaperMakingOrder", "PaperId", "dbo.Paper");
            DropForeignKey("dbo.PaperMakingOrder", "BookCompanyId", "dbo.BookCompany");
            DropForeignKey("dbo.PaperInstock", "PrintShopId", "dbo.PrintShop");
            DropForeignKey("dbo.BookPrintOrder", "PrintShopId", "dbo.PrintShop");
            DropForeignKey("dbo.PaperInstock", "PaperId", "dbo.Paper");
            DropForeignKey("dbo.Paper", "PaperBrandId", "dbo.PaperBrand");
            DropForeignKey("dbo.PaperBrand", "PaperMillId", "dbo.PaperMill");
            DropForeignKey("dbo.BookPrintOrder", "BookEditonId", "dbo.BookEditon");
            DropForeignKey("dbo.BookEditon", "BookId", "dbo.Book");
            DropForeignKey("dbo.BookPrintOrder", "BookCompanyId", "dbo.BookCompany");
            DropIndex("dbo.BookInstock", new[] { "PrintShopId" });
            DropIndex("dbo.BookInstock", new[] { "BookId" });
            DropIndex("dbo.PaperNeed", new[] { "BookPrintOrderId" });
            DropIndex("dbo.PaperNeed", new[] { "PaperId" });
            DropIndex("dbo.PaperMakingOrder", new[] { "PaperSpec_PaperSpecId" });
            DropIndex("dbo.PaperMakingOrder", new[] { "PrintShopId" });
            DropIndex("dbo.PaperMakingOrder", new[] { "PaperId" });
            DropIndex("dbo.PaperMakingOrder", new[] { "BookCompanyId" });
            DropIndex("dbo.PaperInstock", new[] { "PaperSpec_PaperSpecId" });
            DropIndex("dbo.PaperInstock", new[] { "PrintShopId" });
            DropIndex("dbo.PaperInstock", new[] { "PaperId" });
            DropIndex("dbo.PaperBrand", new[] { "PaperMillId" });
            DropIndex("dbo.Paper", new[] { "PaperSpecId" });
            DropIndex("dbo.Paper", new[] { "PaperBrandId" });
            DropIndex("dbo.BookEditon", new[] { "BookId" });
            DropIndex("dbo.BookPrintOrder", new[] { "Paper_PaperId" });
            DropIndex("dbo.BookPrintOrder", new[] { "PrintShopId" });
            DropIndex("dbo.BookPrintOrder", new[] { "BookCompanyId" });
            DropIndex("dbo.BookPrintOrder", new[] { "BookEditonId" });
            DropTable("dbo.BookInstock");
            DropTable("dbo.PaperNeed");
            DropTable("dbo.PaperMakingOrder");
            DropTable("dbo.PrintShop");
            DropTable("dbo.PaperInstock");
            DropTable("dbo.PaperSpec");
            DropTable("dbo.PaperMill");
            DropTable("dbo.PaperBrand");
            DropTable("dbo.Paper");
            DropTable("dbo.Book");
            DropTable("dbo.BookEditon");
            DropTable("dbo.BookPrintOrder");
            DropTable("dbo.BookCompany");
        }
    }
}
