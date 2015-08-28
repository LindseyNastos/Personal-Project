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
    using System.Collections.Generic;
    using System.Configuration;

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

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var adminEmail = ConfigurationManager.AppSettings["adminEmail"];
            var adminPassword = ConfigurationManager.AppSettings["adminPassword"];

            // Ensure Lindsey
            var user = userManager.FindByName(adminEmail);
            if (user == null)
            {
                // create user
                user = new ApplicationUser
                {
                    DisplayName = "Lindsey",
                    UserName = adminEmail,
                    Email = adminEmail,
                };
                userManager.Create(user, adminPassword);

                // add claims
                userManager.AddClaim(user.Id, new Claim("IsAdmin", "true"));
            }
        }
    }
}