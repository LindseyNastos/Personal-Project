namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherMig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Boards", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Boards", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            DropColumn("dbo.Boards", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boards", "User", c => c.String());
            RenameIndex(table: "dbo.Boards", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Boards", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
