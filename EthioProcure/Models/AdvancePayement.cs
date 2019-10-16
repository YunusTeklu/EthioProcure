using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class AdvancePayement
    {
        public int AdvancePayementId { get; set; }
        public float apRate { get; set; }
        public int apNumber { get; set; }
        public float amount { get; set; }

        public Project project { get; set; }
        

    }
}