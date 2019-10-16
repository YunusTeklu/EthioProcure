using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthioProcure.Models
{
    public class Bid
    {
        public int BidId { get; set; }

        [Display(Name ="Methodology")]
        [Required(ErrorMessage ="Please enter the methodology of the project.")]
        public String methodology { get; set; }

        [Display(Name = "Implementation Plan")]
        [Required(ErrorMessage = "Please enter the implementation plan of the project.")]
        public String implementationPlan { get; set; }

        [Display(Name = "Work Schedule")]
        public String workSchedule { get; set; }

        [Display(Name = "Bid Security")]
        public byte[] bidSecurity { get; set; }

        public String bsName { get; set; }

        [Display(Name = "Certificate of Site Visit")]
        public byte[] certificateOfSiteVisit { get; set; }

        public String csvName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String completedBillofQuantity { get; set; }
        
        public virtual Tender tender { get; set; }
        [Display(Name ="Project Title")]
        public int TenderId { get; set; }

        public virtual Contractor contractor { get; set; }
        [Display(Name ="Contractor")]
        public int OrganizationId { get; set; }




    }
}