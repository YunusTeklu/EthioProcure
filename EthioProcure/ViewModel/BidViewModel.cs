using EthioProcure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.ViewModel
{
    public class BidViewModel
    {
        public Bid bid { get; set; }
        public Tender tender { get; set; }
        public Contractor contractor { get; set; }
    }
}