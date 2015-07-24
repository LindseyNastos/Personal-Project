namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardReferenceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "ReferenceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "ReferenceId");
        }
    }
}
