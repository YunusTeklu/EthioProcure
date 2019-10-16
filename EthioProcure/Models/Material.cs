using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public String name { get; set; }
        public String unitIn { get; set; }
        public float unitPrice { get; set; }

        public virtual ICollection<Supplier> suppliers { get; set; }
        public virtual ICollection<Order> order { get; set; }
    }
}