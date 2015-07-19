namespace Quinterest.Migrations
{
    using Quinterest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quinterest.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Quinterest.Models.DataContext context)
        {

            var categories = new Category[]
            {
                new Category {Name="Vacations"},
                new Category {Name="People"}
            };

            context.Categories.AddOrUpdate(c => c.Name, categories);


            var pinCategories = new PinCategory[]
            {
                new PinCategory {Name="Travel"},
                new PinCategory {Name="Home Decor"},
                new PinCategory {Name="DIY & Crafts"}
            };

            context.PinCategories.AddOrUpdate(p => p.Name, pinCategories);


           

            var pins = new Pin[]
            {
                new Pin {
                    Title="Deck Decor",
                    ImageUrl="https://www.pinterest.com/pin/443323157046323144/",
                    PinCategoryId=pinCategories[1].Id
                },
                new Pin {
                    Title="Trivoli, Lazio, Italy",
                    ImageUrl="https://s-media-cache-ak0.pinimg.com/736x/b5/b0/68/b5b0686921244cdd7106668228392045.jpg",
                    PinCategoryId=pinCategories[0].Id
                },
                new Pin {
                    Title="Painting Glassware",
                    ImageUrl="https://s-media-cache-ak0.pinimg.com/736x/e9/5f/b2/e95fb2616c2de686c783e318b1606c01.jpg",
                    PinCategoryId=pinCategories[2].Id
                }
            };

            context.Pins.AddOrUpdate(p => p.Title, pins);

            var boards = new Board[]
            {
                new Board {
                    BoardName="My Dream Home", 
                    Description="Someday when I'm a rich web developer and swimming in cash, I'll have a house with all the stuff on this board :P", 
                    Secret=false,
                    CategoryId=categories[0].Id,
                    NumPinsInBoard=46
                },
                new Board {
                    BoardName="Fast Cars",
                    Description="Nuff said.", 
                    Secret=false,
                    CategoryId=categories[0].Id,
                    NumPinsInBoard=11
                },
                new Board {
                    BoardName="If I Had Way Too Much Time On My Hands", 
                    Description="Stuff I would love to do, but will never have time for, unless I'm procrastinating on my CoderCamps homework...", 
                    Secret=false,
                    CategoryId=categories[0].Id,
                    NumPinsInBoard=167
                },
                new Board {
                    BoardName="Celebrity Crushes", 
                    Description="No one else can see this board!", 
                    Secret=true,
                    CategoryId=categories[1].Id,
                    NumPinsInBoard=22
                },
            };
            context.Boards.AddOrUpdate(b => b.BoardName, boards);


             var profiles = new Profile[]
            {
                new Profile {
                    Name="Lindsey Nastos",
                    NumBoards=4,
                    NumPins=143,
                    //Boards={ boards.[0], boards.[1], boards.[3] }
                }
            };

            context.Profiles.AddOrUpdate(p => p.Id, profiles);

        }
    }
}
