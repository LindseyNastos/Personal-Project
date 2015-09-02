using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int PinId { get; set; }
        public Pin Pin { get; set; }
    }
}