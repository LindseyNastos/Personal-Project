using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class CategoryPage
    {
        public string Title { get; set; }

        //public Subcategory Subcategories { get; set; }

        public List<Pin> PinsInCategory { get; set; }
    }
}


/*
				-catagory title
				-related interests (sub catagories)
				-random list of pins in that catagory (infinite scrolling)
*/