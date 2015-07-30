using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Views.Pins
{
    public class DetailsVM
    {
        public Pin Pin { get; set; }

        public ApplicationUser CurrentUser { get; set; }

        public string PinnerDisplayName { get; set; }

        public IList<Comment> Comments { get; set; }

        public Comment Comment { get; set; }

    }
}