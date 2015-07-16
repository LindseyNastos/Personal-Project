using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class Board
    {
        public string BoardName { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public Category Categories { get; set; }

        public bool Secret { get; set; }

        public string NumPinsInBoard { get; set; }

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