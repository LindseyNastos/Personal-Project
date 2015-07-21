namespace Quinterest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jonathanRonald : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardName = c.String(nullable: false),
                        Description = c.String(),
                        NumPinsOnBoard = c.Int(nullable: false),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.Pins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        Website = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ShortDescription = c.String(maxLength: 150),
                        LongDescription = c.String(maxLength: 1000),
                        Board_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.Board_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        NumBoards = c.Int(nullable: false),
                        NumPins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Pins", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Pins", "Board_Id", "dbo.Boards");
            DropIndex("dbo.Pins", new[] { "Board_Id" });
            DropIndex("dbo.Pins", new[] { "CategoryId" });
            DropIndex("dbo.Boards", new[] { "Profile_Id" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Categories");
            DropTable("dbo.Pins");
            DropTable("dbo.Boards");
        }
    }
}
