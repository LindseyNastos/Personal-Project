using Quinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Views.Pins
{
    public class CreateVM
    {
        public Pin Pin { get; set; }

        public SelectList PinCategories { get; set; }

    }
}
