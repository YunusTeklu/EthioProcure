using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public float amountTransfered { get; set; }
        public Project project { get; set; }
        public Order order { get; set; }

    }
}