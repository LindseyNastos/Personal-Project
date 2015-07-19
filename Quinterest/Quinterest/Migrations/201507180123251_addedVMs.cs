namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedVMs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pins", "CategoryId", "dbo.PinCategories");
            DropIndex("dbo.Pins", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Pins", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Pins", "Category_Id", c => c.Int());
            CreateIndex("dbo.Pins", "Category_Id");
            AddForeignKey("dbo.Pins", "Category_Id", "dbo.PinCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pins", "Category_Id", "dbo.PinCategories");
            DropIndex("dbo.Pins", new[] { "Category_Id" });
            AlterColumn("dbo.Pins", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Pins", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Pins", "CategoryId");
            AddForeignKey("dbo.Pins", "CategoryId", "dbo.PinCategories", "Id", cascadeDelete: true);
        }
    }
}
