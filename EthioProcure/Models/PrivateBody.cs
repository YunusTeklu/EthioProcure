using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class PrivateBody: Organization
    {
        [Display(Name= "Tax Payer Registration Certificate(TIN No)")]
        public byte[] tinReg { get; set; }

        [StringLength(255)]
        public String tinName { get; set; }

        //[ValidateFile]
        [Display(Name = "Business Licence")]
        //[Required(ErrorMessage = "Please upload a valid business licence")]
        public byte[] businessLicence { get; set; }

        [StringLength(255)]
        public String blName { get; set; }
    }
}