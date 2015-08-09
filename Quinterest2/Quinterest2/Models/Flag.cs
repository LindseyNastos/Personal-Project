using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Models
{
    public class Flag
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Pin Pin { get; set; }

        public int PinId { get; set; }

    }
}