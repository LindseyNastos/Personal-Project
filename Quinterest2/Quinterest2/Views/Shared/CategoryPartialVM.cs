using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest2.Views.Shared
{
    public class CategoryPartialVM
    {
        public SelectList Categories { get; set; }
        public Pin Pin { get; set; }

    }
}