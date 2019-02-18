using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBokk1.Models
{
    public class Book 
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfLastMove { get; set; }       
        public string Words { get; set; }
        public int OwnerLoginID { get; set; }
        public int CarrierLoginID { get; set; }
        public int BookStatus { get; set; }

        public int Circulation { get; set; }
        public int Sent { get; set; }
        public int Receive { get; set; }

        public string TL { get; set; }

    }
}