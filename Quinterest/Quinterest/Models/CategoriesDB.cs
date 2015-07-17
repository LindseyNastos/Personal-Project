using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class CategoriesDB : DbContext
    {
        public CategoriesDB()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }


        public IDbSet<Pin> Pins { get; set; }
    }
}