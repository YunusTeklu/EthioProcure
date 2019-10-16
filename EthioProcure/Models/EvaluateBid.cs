using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EthioProcure.Models
{
    public class EvaluateBid
    {
        public int EvaluateBidId { get; set; }

        [Display(Name ="Contractor Type Score")]
        public int contractorTypeScore { get; set; }

        [Display(Name = "Contractor Level Score")]
        public int contractorLevelScore { get; set; }

        [Display(Name = "Methodology Score")]
        public int methodologyScore { get; set; }

        [Display(Name = "Work Schdule Score")]
        public int workScheduleScore { get; set; }

        [Display(Name = "Implementation Plan Score")]
        public int implementationPlanScore { get; set; }

        [Display(Name = "Tax Registration Score")]
        public bool tinScore { get; set; }

        [Display(Name = "Busines Licence Score")]
        public bool busLiScore { get; set; }

        [Display(Name = "Competency Score")]
        public bool cocScore { get; set; }

        [Display(Name = "Audit Report Score")]
        public bool audRepScore { get; set; }

        [Display(Name = "Machinary Certificate Score")]
        public bool machCertScore { get; set; }

        [Display(Name = "Professional Certificate Score")]
        public bool profCertScore { get; set; }

        [Display(Name = "Performance Letters Score")]
        public bool perfLetScore { get; set; }

        [Display(Name = "Tax Clearence Score")]
        public bool taxClrScore { get; set; }

        [Display(Name = "VAT Registration Score")]
        public bool vatRegScore { get; set; }

        [Display(Name = "FPPA Registration Score")]
        public bool fppaRegScore { get; set; }

        [Display(Name = "Bid Security Score")]
        public bool bidSecScore { get; set; }

        [Display(Name = "Certificate of Site Visit Score")]
        public bool csvScore { get; set; }

        [Display(Name = "Annual Turnover Score")]
        public int anualTurnoverScore { get; set; }

        [Display(Name = "Professional Qualifications Score")]
        public int profQuaScore { get; set; }

        [Display(Name = "Equipment Score")]
        public int equipScore { get; set; }

        public int[] boqUnitRateScores { get; set; }
        
        public virtual Bid bid { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BidId { get; set; }
    }
}