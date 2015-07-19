using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quinterest.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime PostTimeStamp { get; set; }

        public string NewComment { get; set; }

        public Pin Pin { get; set; }

    }
}
