namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buddy : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Boards", "CategoryId");
            AddForeignKey("dbo.Boards", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Boards", new[] { "CategoryId" });
        }
    }
}
