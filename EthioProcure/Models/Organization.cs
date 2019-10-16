using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }

        [Required(ErrorMessage ="Please insert Organization Name")]
        [StringLength(255)]
        [Display(Name = "Organization Name")]
        public String organizationName { get; set; }

        //[ValidateFile]
        [Display(Name = "Logo")]
        public byte[] logo { get; set; }

        [StringLength(255)]
        public String logoName { get; set; }

        [Display(Name = "Description")]
        public String description { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        public String email { get; set; }

        [Phone]
        [Display(Name = "Telephone")]
        public String telephone { get; set; }
        
    }
}