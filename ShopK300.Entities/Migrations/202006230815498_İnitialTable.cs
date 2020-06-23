namespace ShopK300.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class İnitialTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Thumbnail = c.Int(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.ProductToPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PictureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductToPictures", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductToPictures", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.ProductToPictures", new[] { "PictureID" });
            DropIndex("dbo.ProductToPictures", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropTable("dbo.Pictures");
            DropTable("dbo.ProductToPictures");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
