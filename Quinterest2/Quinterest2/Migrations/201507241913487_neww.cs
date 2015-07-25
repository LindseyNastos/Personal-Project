namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Pins", "UserId");
            AddForeignKey("dbo.Pins", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Pins", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pins", "User", c => c.String());
            DropForeignKey("dbo.Pins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Pins", new[] { "UserId" });
            DropColumn("dbo.Pins", "UserId");
        }
    }
}
