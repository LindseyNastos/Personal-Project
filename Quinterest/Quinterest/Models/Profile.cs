﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest.Models
{
    public class Profile
    {
    }
}











/*
PROFILE
    -top nav bar
    -buttons to edit profile
    -drop down button for settings
        -account settings
        -log out
    -picture
    -name
    -stats (5 different views, boards is default):
        -number of boards (shows boards)
        -number of pins (shows all pins, with most recent first)
        -number of likes (shows pins you've liked)
        -number of followers (shows pinners with button to follow them)
        -number following (shows topics, pinners, and boards)
    -when you click stats - takes you to that view
    -boards view:
        -first board is a blank template to create board
        -board name
        -main picture (first pinned - you can change to whichever pin you want)
        -small icon with number of pins on that board
        -three smaller pictures below main picture
        -button to edit:
            -EDIT BOARD modal (same as create board modal):
                -can change:
                    -name of board
                    -description of board
                    -category
                    -cover photo
                        -Change Board Cover / board
                        -picture - can flip to next picture
                        -buttons to cancel or save changes
                    -map (can tag it to a location)
                    -delete board
        -secret boards in different section at the bottom of the others
        -first board in secret section is a blank template to create secret board
    -when you click a specific pin:
        -same as expanded version
        -also has an edit button:
            -can change:
                -board
                -description
                -website
                -place
            -button to cancel
            -button to delete pin
*/