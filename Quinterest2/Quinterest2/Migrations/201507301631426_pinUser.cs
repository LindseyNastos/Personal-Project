namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pinUser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pins", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Pins", "UserId");
            RenameColumn(table: "dbo.Pins", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Pins", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Pins", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pins", new[] { "UserId" });
            AlterColumn("dbo.Pins", "UserId", c => c.String());
            RenameColumn(table: "dbo.Pins", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Pins", "UserId", c => c.String());
            CreateIndex("dbo.Pins", "ApplicationUser_Id");
        }
    }
}
