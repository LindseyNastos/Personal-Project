using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quinterest2.Models
{
    public class Board
    {
        public int Id { get; set; }


        [Required(ErrorMessage="*required")]
        [Display(Name = "Board Name")]
        public string BoardName { get; set; }


        public string Description { get; set; }


        public Profile Profile { get; set; }


        public int NumPinsOnBoard { get; set; }


        public List<Pin> Pins { get; set; }
        
        
        //Maybe add later?
        //public bool Secret { get; set; }
    }
}