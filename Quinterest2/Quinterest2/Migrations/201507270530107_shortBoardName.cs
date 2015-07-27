namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shortBoardName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "BoardName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boards", "BoardName", c => c.String(nullable: false));
        }
    }
}
