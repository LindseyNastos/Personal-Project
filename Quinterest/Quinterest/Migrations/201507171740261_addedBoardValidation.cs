namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBoardValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "BoardName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boards", "BoardName", c => c.String());
        }
    }
}
