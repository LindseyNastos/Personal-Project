namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificationsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Message = c.String(),
                        PinId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pins", t => t.PinId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.PinId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "PinId", "dbo.Pins");
            DropIndex("dbo.Notifications", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Notifications", new[] { "PinId" });
            DropTable("dbo.Notifications");
        }
    }
}
