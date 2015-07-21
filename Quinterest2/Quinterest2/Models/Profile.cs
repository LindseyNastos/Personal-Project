using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quinterest2.Models
{
    public class Profile
    {
        public int Id { get; set; }


        public string Name { get; set; }


        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }


        public int NumBoards { get; set; }


        public int NumPins { get; set; }


        public List<Board> Boards { get; set; }
    }
}