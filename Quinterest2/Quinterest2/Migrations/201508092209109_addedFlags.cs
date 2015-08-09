namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFlags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Pin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pins", t => t.Pin_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Pin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flags", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Flags", "Pin_Id", "dbo.Pins");
            DropIndex("dbo.Flags", new[] { "Pin_Id" });
            DropIndex("dbo.Flags", new[] { "UserId" });
            DropTable("dbo.Flags");
        }
    }
}
