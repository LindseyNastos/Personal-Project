namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pinViewsCreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pins", "Category_Id", "dbo.PinCategories");
            DropIndex("dbo.Pins", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Pins", name: "Category_Id", newName: "PinCategoryId");
            AlterColumn("dbo.Pins", "PinCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pins", "PinCategoryId");
            AddForeignKey("dbo.Pins", "PinCategoryId", "dbo.PinCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pins", "PinCategoryId", "dbo.PinCategories");
            DropIndex("dbo.Pins", new[] { "PinCategoryId" });
            AlterColumn("dbo.Pins", "PinCategoryId", c => c.Int());
            RenameColumn(table: "dbo.Pins", name: "PinCategoryId", newName: "Category_Id");
            CreateIndex("dbo.Pins", "Category_Id");
            AddForeignKey("dbo.Pins", "Category_Id", "dbo.PinCategories", "Id");
        }
    }
}
