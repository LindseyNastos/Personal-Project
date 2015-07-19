namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "NumPinsInBoard", c => c.Int(nullable: false));
            DropColumn("dbo.Profiles", "NumLikes");
            DropColumn("dbo.Profiles", "NumFollowers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "NumFollowers", c => c.Int(nullable: false));
            AddColumn("dbo.Profiles", "NumLikes", c => c.Int(nullable: false));
            AlterColumn("dbo.Boards", "NumPinsInBoard", c => c.String());
        }
    }
}
