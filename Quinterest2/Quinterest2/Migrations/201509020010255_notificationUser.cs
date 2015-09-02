namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificationUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notifications", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Notifications", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notifications", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Notifications", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
