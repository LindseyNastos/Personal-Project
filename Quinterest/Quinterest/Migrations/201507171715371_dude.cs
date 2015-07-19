namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dude : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boards", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Boards", new[] { "CategoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Boards", "CategoryId");
            AddForeignKey("dbo.Boards", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
