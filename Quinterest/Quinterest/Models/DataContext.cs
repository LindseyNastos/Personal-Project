using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        public IDbSet<Pin> Pins { get; set; }

        public IDbSet<Board> Boards { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<PinCategory> PinCategories { get; set; }

        public IDbSet<Profile> Profiles { get; set; }


    }
}