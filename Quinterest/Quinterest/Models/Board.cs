using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class Board
    {
        public int Id { get; set; }

        public string BoardName { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        //drop down menu of categories to choose from on "create" board view
        public Category Categories { get; set; }

        public bool Secret { get; set; }

        public string NumPinsInBoard { get; set; }

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