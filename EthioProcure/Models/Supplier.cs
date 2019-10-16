using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EthioProcure.Models
{
    public class Supplier: PrivateBody
    {
        [Display(Name ="Bank Name")]
        [Required(ErrorMessage ="Please enter a bank name to which your account resides")]
        [StringLength(255)]
        public String bankName { get; set; }

        [Display(Name = "Account No.")]
        [Required(ErrorMessage = "Please enter an account number")]
        [StringLength(255)]
        public String accountNo { get; set; }

        public virtual ICollection<Material> naterials { get; set; }
    }
}