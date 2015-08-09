namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numFlags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "NumFlags", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pins", "NumFlags");
        }
    }
}
