using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class PublicBody: Organization
    {
        [Display(Name = "Public Certificate")]
        public byte[] publicCertificate { get; set; }

        [StringLength(255)]
        public String pcName { get; set; }
    }
}