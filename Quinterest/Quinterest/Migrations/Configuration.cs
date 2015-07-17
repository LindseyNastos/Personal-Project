namespace Quinterest.Migrations
{
    using Quinterest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quinterest.Models.BoardsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Quinterest.Models.BoardsDB context)
        {
            var boards = new Board[]
            {
                new Board {
                    BoardName="My Dream Home", 
                    Description="Someday when I'm a rich web developer and swimming in cash, I'll have a house with all the stuff on this board :P", 
                    Secret=false
                },
                new Board {
                    BoardName="Fast Cars",
                    Description="Nuff said.", 
                    Secret=false
                },
                new Board {
                    BoardName="If I Had Way Too Much Time On My Hands", 
                    Description="Stuff I would love to do, but will never have time for, unless I'm procrastinating on my CoderCamps homework...", 
                    Secret=false
                },
                new Board {
                    BoardName="Celebrity Crushes", 
                    Description="No one else can see this board!", 
                    Secret=true
                },
            };
            context.Boards.AddOrUpdate(b => b.BoardName, boards);
        }
    }
}
