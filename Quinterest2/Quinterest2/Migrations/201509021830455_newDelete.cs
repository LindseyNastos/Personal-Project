namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pins", "IsActive");
        }
    }
}
