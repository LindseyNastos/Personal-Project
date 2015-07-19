using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest.Models
{
    public class Board
    {
        public int Id { get; set; }

        //[Remote("ValidateBoardName", "Boards", ErrorMessage="*board name already exists", HttpMethod = "Post")]
        [Required(ErrorMessage="*required")]
        public string BoardName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //drop down menu of categories to choose from on "create" board view

        public bool Secret { get; set; }

        public int NumPinsInBoard { get; set; }

        //holds list of pins to be displayed on board on "index" view
        public List<Pin> PinsOnBoard { get; set; }

    }
}




/*
-when you click a specific board:
		-board name
		-button that links to profile
		-number of pins
		-button to edit board
		-list of pins
*/