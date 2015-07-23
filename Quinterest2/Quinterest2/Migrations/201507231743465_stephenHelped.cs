namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stephenHelped : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pins", "Board_Id", "dbo.Boards");
            DropIndex("dbo.Pins", new[] { "Board_Id" });
            RenameColumn(table: "dbo.Pins", name: "Board_Id", newName: "BoardId");
            AlterColumn("dbo.Pins", "BoardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pins", "BoardId");
            AddForeignKey("dbo.Pins", "BoardId", "dbo.Boards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pins", "BoardId", "dbo.Boards");
            DropIndex("dbo.Pins", new[] { "BoardId" });
            AlterColumn("dbo.Pins", "BoardId", c => c.Int());
            RenameColumn(table: "dbo.Pins", name: "BoardId", newName: "Board_Id");
            CreateIndex("dbo.Pins", "Board_Id");
            AddForeignKey("dbo.Pins", "Board_Id", "dbo.Boards", "Id");
        }
    }
}
