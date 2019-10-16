using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public String bankName { get; set; }
        public String projectAccountNo { get; set; }
        public byte[] projectContract { get; set; }
        public byte[] letterOfAcceptence { get; set; }

        public Contractor contractor { get; set; }
        public Consultant consultant { get; set; }
        public virtual ICollection<Order> order { get; set; }
    }
}