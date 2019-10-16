using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Consultant: PrivateBody
    {
        [Display(Name = "Consultancy Contract")]
        public byte[] consultancyContract { get; set; }

        [StringLength(255)]
        public String ccname { get; set; }
    }
}