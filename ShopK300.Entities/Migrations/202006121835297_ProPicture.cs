namespace ShopK300.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProPicture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductToPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pictures", t => t.PictureId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductToPictures", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductToPictures", "PictureId", "dbo.Pictures");
            DropIndex("dbo.ProductToPictures", new[] { "PictureId" });
            DropIndex("dbo.ProductToPictures", new[] { "ProductID" });
            DropTable("dbo.Pictures");
            DropTable("dbo.ProductToPictures");
        }
    }
}
