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


        public int ReferenceId { get; set; }


        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        public string User { get; set; }



        [Display(Name = "Pins")]
        public int NumPinsOnBoard { get; set; }


        public ICollection<Pin> Pins { get; set; }


        public Board()
        {
            this.Pins = new List<Pin>();
        }
        
        
        //Maybe add later?
        //public bool Secret { get; set; }
    }
}