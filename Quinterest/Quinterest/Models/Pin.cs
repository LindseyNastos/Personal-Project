using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class Pin
    {
        public int Id { get; set; }


        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "*required")]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }


        public string Website { get; set; }


        [Required(ErrorMessage = "*required")]
        public string Title { get; set; }

        //Holds the chosen board
        public string Board { get; set; }

        public List<Board> Boards { get; set; }

        //Holds the chosen category
        public int CategoryId { get; set; }

        //To choose which category it belongs to in "create" view
        public Category Category { get; set; }


        public string UserWhoPinned { get; set; }


        [MaxLength(150, ErrorMessage = "*limit: 150 characters")]
        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }


        [MaxLength(1000, ErrorMessage = "*limit: 1000 characters")]
        [Display(Name = "Long Description")]
        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }


        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "*limit: 500 characters")]
        public string NewComment { get; set; }


        //public List<Comment> CommentList { get; set; }


        public List<Pin> RelatedPins { get; set; }


    }
}




/*
-when you click picture, each has an EXPANDED VERSION
		-you can Pin it, Like it, Visit it's site, Send it, or Share it (on social media)
		-bigger version of image (clickable - takes you to website its from)
		-link to site its from
		-Title and user's name who pinned it
		-User's brief description
		-Expanded description
		-comment section
		-shows other boards that that particular pin is on (from other users)
		-shows related pins
		-to side of picture:
			-can click on board (with option to follow board)
			-can see more pins from the same website
*/