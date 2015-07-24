using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quinterest2.Models
{
    public class Pin
    {
        public int Id { get; set; }


       [Required(ErrorMessage = "*required")]
        public string Title { get; set; }


        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "*required")]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }


        public string Website { get; set; }


        public int BoardId { get; set; }


        public Board Board { get; set; }


        public int CategoryId { get; set; }


        public Category Category { get; set; }


        [MaxLength(150, ErrorMessage = "*limit: 150 characters")]
        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        [MaxLength(1000, ErrorMessage = "*limit: 1000 characters")]
        [Display(Name = "Long Description")]
        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }


        //Maybe add later?
        //public string UserWhoPinned { get; set; }
        //public List<Comment> Comments { get; set; }
        //public List<Pin> RelatedPins { get; set; }
    }
}