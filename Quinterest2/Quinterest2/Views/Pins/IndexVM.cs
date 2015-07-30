using Quinterest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quinterest2.Views.Pins
{
    public class IndexVM
    {
        public IList<Pin> Pins { get; set; }

        public int PinCount { get; set; }

    }
}