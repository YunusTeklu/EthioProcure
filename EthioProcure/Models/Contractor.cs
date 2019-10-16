using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthioProcure.Models
{
    public class Contractor: PrivateBody
    {
        [Range(1,10)]
        [Required(ErrorMessage ="Please insert Contractor Level")]
        [Display(Name = "Contractor Level")]
        public int contractorLevel { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public String empTable { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String annualTurnover { get; set; }

        [Required(ErrorMessage = "Please select Contractor Type")]
        [Display(Name = "Contractor Type")]
        public String contractorType { get; set; }

        //[Required(ErrorMessage = "Please upload a Certificate of Competency")]
        //[ValidateFile]
        [Display(Name = "Certificate of Competency")]
        public byte[] certificateOfCompetency { get; set; }

        [StringLength(255)]
        public String cocName { get; set; }

        //[Required(ErrorMessage = "Please upload Audit Report for the past year")]
        //[ValidateFile]
        [Display(Name = "Audit Report")]
        public byte[] auditReport { get; set; }

        [StringLength(255)]
        public String arName { get; set; }

        //[Required(ErrorMessage = "Please upload Machinary Certificate for the equipments possessed")]
        //[ValidateFile]
        [Display(Name = "Machinary Certificate")]
        public byte[] machinaryCertificate { get; set; }

        [StringLength(255)]
        public String mcName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public String machEquipTable { get; set; }

        [Display(Name = "Organizational Structure")]
        public byte[] orgStruct { get; set; }

        [StringLength(255)]
        public String orgStrName { get; set; }

        //[Required(ErrorMessage = "Please upload the CV of the staff of Engineers employed")]
        //[ValidateFile]
        [Display(Name = "Relevant Professional and Practice Certificate")]
        public byte[] staffCV { get; set; }

        [StringLength(255)]
        public String scName { get; set; }

        //[Required(ErrorMessage = "Please upload a performance letter")]
        //[ValidateFile]
        [Display(Name = "Performance Letters")]
        public byte[] performanceletter { get; set; }

        [StringLength(255)]
        public String plName { get; set; }

        [Display(Name ="VAT Registration Certificate")]
        public byte[] vatRegistration { get; set; }

        [StringLength(255)]
        public String vatRagName { get; set; }

        [Display(Name ="Tax Clearance")]
        public byte[] taxClearance { get; set; }

        [StringLength(255)]
        public String taxClrName { get; set; }

        [Display(Name ="FPPA Supplier List Registration")]
        public byte[] fppaReg { get; set; }

        [StringLength(255)]
        public String fppaRegName { get; set; }
    }
}