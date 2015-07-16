using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        
        
        
        //eventually this should list additional tags it will link to (Travel > Beach Travel ==> "travel" & "beach")
        public string Name { get; set; }
    }
}