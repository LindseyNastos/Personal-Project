﻿using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quinterest2.Views.Pins
{
    public class PinItViewVM
    {
        public Pin Pin { get; set; }
        public SelectList Boards { get; set; }
        public SelectList Categories { get; set; }
    }
}