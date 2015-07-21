using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quinterest2.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Profile> Profiles { get; set; }

        public IDbSet<Board> Boards { get; set; }

        public IDbSet<Pin> Pins { get; set; }

        public IDbSet<Category> Categories { get; set; }
    }
}