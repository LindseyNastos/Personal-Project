namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flagAdjusted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flags", "Pin_Id", "dbo.Pins");
            DropIndex("dbo.Flags", new[] { "Pin_Id" });
            RenameColumn(table: "dbo.Flags", name: "Pin_Id", newName: "PinId");
            AlterColumn("dbo.Flags", "PinId", c => c.Int(nullable: false));
            CreateIndex("dbo.Flags", "PinId");
            AddForeignKey("dbo.Flags", "PinId", "dbo.Pins", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flags", "PinId", "dbo.Pins");
            DropIndex("dbo.Flags", new[] { "PinId" });
            AlterColumn("dbo.Flags", "PinId", c => c.Int());
            RenameColumn(table: "dbo.Flags", name: "PinId", newName: "Pin_Id");
            CreateIndex("dbo.Flags", "Pin_Id");
            AddForeignKey("dbo.Flags", "Pin_Id", "dbo.Pins", "Id");
        }
    }
}
