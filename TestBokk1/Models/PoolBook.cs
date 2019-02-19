using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBokk1.Models
{
    public class PoolBook
    {
        public int ID { get; set; }
        public int Owner { get; set; }
        public int HandTo { get; set; }
        public int BookID { get; set; }

    }
}