namespace Quinterest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class son : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoardName = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Secret = c.Boolean(nullable: false),
                        NumPinsInBoard = c.String(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        Website = c.String(),
                        Title = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserWhoPinned = c.String(),
                        ShortDescription = c.String(maxLength: 150),
                        LongDescription = c.String(maxLength: 1000),
                        NewComment = c.String(maxLength: 500),
                        Board_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.Board_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostTimeStamp = c.DateTime(nullable: false),
                        NewComment = c.String(),
                        Pin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pins", t => t.Pin_Id)
                .Index(t => t.Pin_Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Picture = c.String(),
                        Name = c.String(),
                        NumBoards = c.Int(nullable: false),
                        NumPins = c.Int(nullable: false),
                        NumLikes = c.Int(nullable: false),
                        NumFollowers = c.Int(nullable: false),
                        NumFollowing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boards", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Comments", "Pin_Id", "dbo.Pins");
            DropForeignKey("dbo.Pins", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Pins", "Board_Id", "dbo.Boards");
            DropForeignKey("dbo.Boards", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "Pin_Id" });
            DropIndex("dbo.Pins", new[] { "Board_Id" });
            DropIndex("dbo.Pins", new[] { "CategoryId" });
            DropIndex("dbo.Boards", new[] { "Profile_Id" });
            DropIndex("dbo.Boards", new[] { "CategoryId" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Comments");
            DropTable("dbo.Pins");
            DropTable("dbo.Categories");
            DropTable("dbo.Boards");
        }
    }
}
