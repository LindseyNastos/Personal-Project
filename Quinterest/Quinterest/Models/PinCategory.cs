using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class PinCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Pin Pin { get; set; }

    }
}