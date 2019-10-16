using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public String orderStatus { get; set; }
        public bool orderValidity { get; set; }
        public float quantity { get; set; }
        public float semiTotal { get; set; }
        public byte[] materialQualityCertificate { get; set; }

        public virtual ICollection<Project> project { get; set; }
        public Supplier supplier { get; set; }
        public virtual ICollection<Material> material { get; set; }



    }
}