using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Shared.Models
{
    public class Driver
    {
        public int QuoteId;
        public string Name { get; set; }
        public Driver()
        {
            Name = "";
        }
    }
}
