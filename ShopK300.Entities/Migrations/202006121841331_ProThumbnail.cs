namespace ShopK300.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProThumbnail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Thumbnail", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Thumbnail");
        }
    }
}
