namespace Quinterest2.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Quinterest2.Models;
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<Quinterest2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Quinterest2.Models.ApplicationDbContext context)
        {



            var categories = new Category[]
            {
                new Category {Name="Animals and Pets"},
                new Category {Name="Architecture"},
                new Category {Name="Art"},
                new Category {Name="Cars and Motorcycles"},
                new Category {Name="Celebrities"},
                new Category {Name="Design"},
                new Category {Name="DIY and Crafts"},
                new Category {Name="Education"},
                new Category {Name="Film, Music and Books"},
                new Category {Name="Food and Drink"},
                new Category {Name="Gardening"},
                new Category {Name="Hair and Beauty"},
                new Category {Name="Health and Fitness"},
                new Category {Name="History"},
                new Category {Name="Holidays and Events"},
                new Category {Name="Home Decor"},
                new Category {Name="Humor"},
                new Category {Name="Illustrations and Posters"},
                new Category {Name="Kids and Parenting"},
                new Category {Name="Men's Fashion"},
                new Category {Name="Outdoors"},
                new Category {Name="Photography"},
                new Category {Name="Products"},
                new Category {Name="Quotes"},
                new Category {Name="Science and Nature"},
                new Category {Name="Sports"},
                new Category {Name="Technology"},
                new Category {Name="Travel"},
                new Category {Name="Weddings"},
                new Category {Name="Women's Fashion"}

            };

            context.Categories.AddOrUpdate(c => c.Name, categories);

            //var boards = new Board[]
            //{
            //    new Board {
            //        BoardName="My Dream Home", 
            //        Description="Someday when I'm a rich web developer and swimming in cash, I'll have a house with all the stuff on this board :P", 
            //        NumPinsOnBoard=46,
            //    },
            //    new Board {
            //        BoardName="Fast Cars",
            //        Description="Nuff said.", 
            //        NumPinsOnBoard=11
            //    },
            //    new Board {
            //        BoardName="If I Had Way Too Much Time On My Hands", 
            //        Description="Stuff I would love to do, but will never have time for, unless I'm procrastinating on my CoderCamps homework...", 
            //        NumPinsOnBoard=167
            //    },
            //    new Board {
            //        BoardName="Celebrity Crushes", 
            //        Description="No one else can see this board!", 
            //        NumPinsOnBoard=22
            //    },
            //};
            //context.Boards.AddOrUpdate(b => b.BoardName, boards);



            //var pins = new Pin[]
            //{
            //    new Pin {
            //        Title="Deck Decor",
            //        ImageUrl="https://www.pinterest.com/pin/443323157046323144/",
            //        CategoryId=categories[15].Id,
            //        Board=boards[0]
            //    },
            //    new Pin {
            //        Title="Trivoli, Lazio, Italy",
            //        ImageUrl="https://s-media-cache-ak0.pinimg.com/736x/b5/b0/68/b5b0686921244cdd7106668228392045.jpg",
            //        CategoryId=categories[27].Id,
            //        Board=boards[2]
            //    },
            //    new Pin {
            //        Title="Painting Glassware",
            //        ImageUrl="https://s-media-cache-ak0.pinimg.com/736x/e9/5f/b2/e95fb2616c2de686c783e318b1606c01.jpg",
            //        CategoryId=categories[6].Id,
            //        Board=boards[1]
            //    }
            //};

            //context.Pins.AddOrUpdate(p => p.Title, pins);

            


           




            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);
           
            // Ensure Lindsey
            var user = userManager.FindByName("Lindsey@gmail.com");
            if (user == null)
            {
                // create user
                user = new ApplicationUser
                {
                    DisplayName = "Lindsey",
                    UserName = "Lindsey@gmail.com",
                    Email = "Lindsey@gmail.com"
                };
                userManager.Create(user, "Secret123!");

                // add claims
                userManager.AddClaim(user.Id, new Claim("CanDeleteFlaggedPins", "true"));
            }


        }
    }
}
