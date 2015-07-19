using Quinterest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Views.Boards
{
    public class EditVM
    {
        public Board Board { get; set; }

        public SelectList Categories { get; set; }

    }
}