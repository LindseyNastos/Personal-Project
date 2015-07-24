namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pinUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "User", c => c.String());
            AddColumn("dbo.Pins", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pins", "User");
            DropColumn("dbo.Boards", "User");
        }
    }
}
