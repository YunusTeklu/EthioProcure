using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthioProcure.Models
{
    public class Tender
    {
        public int TenderId { get; set; }

        [Display(Name = "Project Title")]
        [StringLength(255)]
        public String projectTitle { get; set; }

        [Display(Name = "Project Scope")]
        [StringLength(255)]
        public String projectScope { get; set; }

        [Display(Name = "Opening Date")]
        public DateTime openingDate { get; set; }

        [Display(Name = "Submission Deadline")]
        public DateTime submissionDeadline { get; set; }

        [Display(Name = "Contract Type")]
        [StringLength(255)]
        public String contractType { get; set; }

        [Display(Name = "Procurement Method")]
        [StringLength(255)]
        public String procurementMethod { get; set; }

        [Display(Name = "Bid Security")]
        [StringLength(255)]
        public String bidSecurity { get; set; }

        [Display(Name = "Required Contractors")]
        [StringLength(255)]
        public String requiredContractors { get; set; }

        [Display(Name = "Contractor Type")]
        [StringLength(255)]
        public String contractorType { get; set; }

        [Display(Name = "Evaluation Method")]
        [StringLength(255)]
        public String evaluationMethod { get; set; }

        [Display(Name = "Standard Bid Document")]
        public byte[] sbd { get; set; }
        public String sbdName { get; set; }

        [Display(Name = "Design")]
        public byte[] design { get; set; }
        public String designName { get; set; }

        [Display(Name = "Bid Validity")]
        public DateTime bidValidity { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String billOfQuantity { get; set; }

        
        public PublicBody publicBody { get; set; }
        public int PublicBodyId { get; set; }
        public Consultant consultant { get; set; }
        public int ConsultantId { get; set; }


    }
}