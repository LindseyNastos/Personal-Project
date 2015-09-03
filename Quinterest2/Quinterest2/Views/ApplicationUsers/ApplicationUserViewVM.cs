using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Views.ApplicationUsers
{
    public class ApplicationUserViewVM
    {
        public ApplicationUser User { get; set; }
        public IList<Board> Boards { get; set; }
    }
}